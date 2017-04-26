$(document).ready(function () {
    $.ajax({
        url: "/api/note",
        dataType: "json",
        success: makeMarkup,
        error: showErrorButton
    });
});

function showErrorButton() {
    document.getElementById("loader").style.display = "none";
    document.getElementById("btn-error").style.display = "initial";
}

function makeMarkup(data, textStatus, xhr) {
    document.getElementById("btn-error").style.display = "";
    document.getElementById("loader").style.display = "none";
    document.getElementById("myDiv").style.display = "initial";

    var noteColumn = 1;

    for (var i = data.length-1; i >= 0 ; i--) {
        if (noteColumn === 1) {
            makeNotesMarkup(i, data, "note-container");
            noteColumn = 2;
        }
        else if (noteColumn === 2) {
            makeNotesMarkup(i, data, "note-container2");
            noteColumn = 1;
        }
    }
};

function makeNotesMarkup(counter, data, container) {
    var noteId = String(data[counter].noteId);

    var divNoteContainer = document.createElement("div");
    divNoteContainer.className = "note-container-div";
    divNoteContainer.id = "note-container-div-" + noteId;

    var menuDiv = document.createElement("div");
    menuDiv.id = "div-menu-" + noteId;
    menuDiv.className = "menu-div";
    var menu = document.createElement("a");
    menu.className = "fa fa-pencil";
    menu.id = "menu-" + noteId;
    menuDiv.appendChild(menu);

    var errorDiv = document.createElement("div");
    errorDiv.className = "error-div";
    errorDiv.id = "error-div-" + noteId;

    var pErrorText = document.createElement("p");
    pErrorText.id = "error-text-" + noteId;
    pErrorText.className = "error-text";

    var noteErrorText = document.createTextNode("Oi, dette funker ikke akkkurat nå.");
    pErrorText.appendChild(noteErrorText);
    errorDiv.appendChild(pErrorText);

    var divNote = document.createElement("div");
    divNote.id = "div-" + noteId;
    divNote.className = "note-div";

    var divHoverButtons = document.createElement("div");
    divHoverButtons.id = "hover-buttons-div-" + noteId;

    var actionDelete = document.createElement("button");
    actionDelete.className = "action-delete";
    actionDelete.id = "action-delete-" + noteId;
    actionDelete.innerHTML = "Delete";

    divHoverButtons.appendChild(actionDelete);

    var actionUpdate = document.createElement("button");
    actionUpdate.className = "action-update";
    actionUpdate.id = "action-update-" + noteId;
    actionUpdate.innerHTML = "Update";

    divHoverButtons.appendChild(actionUpdate);

    var pNote = document.createElement("p");
    pNote.id = "p-note-" + noteId;

    var noteText = document.createTextNode(data[counter].text);
  
    pNote.appendChild(noteText);
    divNote.appendChild(pNote);
   
    var textButtonsDiv = document.createElement("div");
    textButtonsDiv.id = "text-button-div-" + noteId;
    textButtonsDiv.className = "text-buttons"

    divNoteContainer.appendChild(menuDiv);
    divNoteContainer.appendChild(errorDiv);
    textButtonsDiv.appendChild(divNote);
    textButtonsDiv.appendChild(divHoverButtons);
    divNoteContainer.appendChild(textButtonsDiv);
    document.getElementById(container).appendChild(divNoteContainer);

    document.getElementById(errorDiv.id).style.display = "none";
}

var menuPreviousId;
var menuCurrentId;
var insideNote;

function hideMenuUtilities(noteId) {
    var deleteButtonId = "action-delete-" + noteId;
    var updateButtonId = "action-update-" + noteId;

    document.getElementById(deleteButtonId).style.display = "none";
    document.getElementById(updateButtonId).style.display = "none";

    var buttonUpdateId = "hover-buttons-div-" + noteId;
    document.getElementById(buttonUpdateId).className = "text-buttons";
}

function showMenuUtilities(noteId) {
    var deleteButtonId = "action-delete-" + noteId;
    var updateButtonId = "action-update-" + noteId;

    document.getElementById(deleteButtonId).style.display = "inline";
    document.getElementById(updateButtonId).style.display = "inline";

    var buttonUpdateId = "hover-buttons-div-" + noteId;
    document.getElementById(buttonUpdateId).className = "menu-bar-clicked";
}

function initialPresentation(noteId) {
    hideMenuUtilities(noteId);

    var noteText = "p-note-" + noteId;

    document.getElementById(noteText).style.opacity = "1";

    var menuId = "menu-" + noteId;
    document.getElementById(menuId).className = "fa fa-pencil";
}

function insideNotePresentation(noteId) {
    showMenuUtilities(noteId);
    var noteText = "p-note-" + noteId;

    document.getElementById(noteText).style.opacity = "0.1";

    var menuId = "menu-" + noteId;
    document.getElementById(menuId).className = "fa fa-times fa-2x";
}

function hideError(noteId) {
    var errorDiv = "error-div-" + noteId;
    document.getElementById(errorDiv).style.display = "none";
}

$(document).on('click', '*[id^="menu-"]', function () {
    menuCurrentId = this.id;
    var noteId = menuCurrentId.replace(/^\D+/g, '');
    hideError(noteId);

    if (menuCurrentId === menuPreviousId) {

        if (insideUpdate) {
            removeUpdateMarkup(noteId);
            insideUpdate = false;
        }
        initialPresentation(noteId);

        menuPreviousId = undefined;

        insideNote = false;
    }
    else {
        if (!insideNote) {

            insideNotePresentation(noteId)
            insideNote = true;
            menuPreviousId = menuCurrentId;
        }
    }
});

$(document).on('click', '*[id^="action-delete-"]', function () {
    var actionDeleteId = this.id;
    var noteId = actionDeleteId.replace(/^\D+/g, '');
    var noteDivId = "note-container-div-" + noteId;
    var noteDelete = document.getElementById(noteDivId);
    insideNote = false;

    $.ajax({
        url: "/api/note/" + noteId,
        method: "DELETE",
        success: function () {
            $(noteDelete).fadeOut(500, function () {
                $(this).remove();
            }); 
        },
        error: function () {
            var divHoverButtons = "hover-buttons-div-" + noteId;
            document.getElementById(divHoverButtons).style.color = "red";
        }
    });
});

function makeUpdatemarkup(noteId) {
    var text = $("#p-note-" + noteId).text();
  
    var form = document.createElement("form");
    form.id = "updateNoteForm";

    var input = document.createElement("textarea");
    input.value = text;
    
    input.setAttribute('type', "text");
    input.className = "update-input";
    input.id = "input-" + noteId;
    input.autofocus = "autofocus";
    var iddd = input.id;

    var outerDiv = "text-button-div-" + noteId;
    outerDiv = document.getElementById(outerDiv);

    var updateDiv = document.createElement("div");
    updateDiv.id = "update-div-" + noteId;
    updateDiv.className = "update-clicked";

    form.appendChild(input);
    updateDiv.appendChild(form);
    outerDiv.appendChild(updateDiv);

    var noteText = "p-note-" + noteId;
    document.getElementById(noteText).style.opacity = "0";

    var saveButton = document.createElement("button");
    saveButton.className = "save-update";
    saveButton.id = "save-update-" + noteId;
    saveButton.setAttribute("type", "submit");

    saveButton.innerHTML = "Save";

    var wholeNoteDiv = "note-container-div-" + noteId;
    var height = document.getElementById(wholeNoteDiv).offsetHeight;
    var heightDiv = height + 150;
    var heightInputField = height + 150 - 100;

    updateDiv.appendChild(saveButton);
    document.getElementById(wholeNoteDiv).style.height = heightDiv + "px";

    document.getElementById(iddd).style.height = heightInputField + "px";
}

function removeUpdateMarkup(noteId) {
    var updateDiv = "update-div-" + noteId;

    document.getElementById(updateDiv).remove();

    var wholeNoteDiv = "note-container-div-" + noteId;
    var height = document.getElementById(wholeNoteDiv).offsetHeight;
    var heightDiv = height - 150;

    document.getElementById(wholeNoteDiv).style.height = "";
}

var insideUpdate;


$(document).on('click', '*[id^="action-update-"]', function () {
    insideUpdate = true;

    var actionUpdateId = this.id;
    var noteId = actionUpdateId.replace(/^\D+/g, '');
    hideMenuUtilities(noteId);
    makeUpdatemarkup(noteId);
});

$(document).on('click', '*[id^="save-update-"]', function () {
    var saveUpdateButtonId = this.id;
    var noteId = saveUpdateButtonId.replace(/^\D+/g, '');
    insideUpdate = false;
    insideNote = false;

    var updatedText = "#input-" + noteId;

    var newNoteContent = $(updatedText).val();
    var putJson = { text: newNoteContent }

    $.ajax({
        url: "/api/note/" + noteId,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(putJson),
        method: "PUT",
        async: true,
        processData: false,
        cache: false,
        success: function () {
            $("#p-note-" + noteId).text(newNoteContent);
            removeUpdateMarkup(noteId);
            initialPresentation(noteId);
        },
        error: function () {
            document.getElementById("error-div-" + noteId).style.display = "initial";
        }
    });
});