namespace Notes.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNote1 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT notes ON");

            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (18, 'Bagasjen bortp� hj�rnet.Bagasjen bortp� hj�rnet. Bagasjen bortp� hj�rnet. Bagasjen bortp� hj�rnet. Bagasjen bortp� hj�rnet. Bagasjen bortp� hj�rnet', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (19, 'N� er det punktum-finale n� m� du pinad� sm�re br�dskivan di sj�l', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (20, 'spise to fiskekaker klokka 5', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (21, 'Huske � plukke jordb�r, p�rer, banener og epler. Huske � plukke jordb�r, p�rer, banener og epler.Huske � plukke jordb�r, p�rer, banener og epler. Huske � plukke jordb�r, p�rer, banener og epler.  .Huske � plukke jordb�r, p�rer, banener og epler. Huske � plukke jordb�r, p�rer, banener og epler. Huske � plukke jordb�r, p�rer, banener og epler.', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (22, 'Bagasjen bortp� hj�rnet igjen, m� huskes', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (23, 'Rottegift lorem impsum lorem impusm har du det bra i dag. Jo takk som sp�r. Tusen takk igjen for at du spurte s� fint.', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (24, 'Puser som luser.N� er det punktum-finale n� m� du pinad� sm�re br�dskivan di sj�l, lille pus.', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
        }
        
        public override void Down()
        {
        }
    }
}
