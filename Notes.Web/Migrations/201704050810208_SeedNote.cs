namespace Notes.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNote : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT notes ON");

            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (11, 'Bagasjen bortp� hj�rnet', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (12, 'N� er det punktum-finale n� m� du pinad� sm�re br�dskivan di sj�l', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (13, 'spise to fiskekaker klokka 5', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (14, 'Huske � plukke jordb�r, p�rer, banener og epler. Huske � plukke jordb�r, p�rer, banener og epler. Huske � plukke jordb�r, p�rer, banener og epler.', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (15, 'Bagasjen bortp� hj�rnet igjen, m� huskes', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (16, 'Rottegift', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (17, 'Puser som luser.N� er det punktum-finale n� m� du pinad� sm�re br�dskivan di sj�l, lille pus.', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
        }
        
        public override void Down()
        {
        }
    }
}
