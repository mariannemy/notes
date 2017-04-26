namespace Notes.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNotes : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT notes ON");

            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (4, 'Bagasjen bortp� hj�rnet', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (5, 'N� er det punktum-finale n� m� du pinad� sm�re br�dskivan di sj�l', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (6, 'spise to fiskekaker klokka 5', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (7, 'Huske � plukke jordb�r, p�rer, banener og epler. Huske � plukke jordb�r, p�rer, banener og epler. Huske � plukke jordb�r, p�rer, banener og epler. Huske � plukke jordb�r, p�rer, banener og epler.', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (8, 'Bagasjen bortp� hj�rnet igjen, m� huskes', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (9, 'Rottegift', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (10, 'Puser som luser', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
        }
        
        public override void Down()
        {
        }
    }
}
