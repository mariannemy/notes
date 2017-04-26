namespace Notes.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNotes : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT notes ON");

            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (4, 'Bagasjen bortpå hjørnet', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (5, 'Nå er det punktum-finale nå må du pinadø smøre brødskivan di sjøl', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (6, 'spise to fiskekaker klokka 5', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (7, 'Huske å plukke jordbær, pærer, banener og epler. Huske å plukke jordbær, pærer, banener og epler. Huske å plukke jordbær, pærer, banener og epler. Huske å plukke jordbær, pærer, banener og epler.', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (8, 'Bagasjen bortpå hjørnet igjen, må huskes', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (9, 'Rottegift', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (10, 'Puser som luser', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
        }
        
        public override void Down()
        {
        }
    }
}
