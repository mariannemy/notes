namespace Notes.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNote1 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT notes ON");

            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (18, 'Bagasjen bortpå hjørnet.Bagasjen bortpå hjørnet. Bagasjen bortpå hjørnet. Bagasjen bortpå hjørnet. Bagasjen bortpå hjørnet. Bagasjen bortpå hjørnet', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (19, 'Nå er det punktum-finale nå må du pinadø smøre brødskivan di sjøl', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (20, 'spise to fiskekaker klokka 5', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (21, 'Huske å plukke jordbær, pærer, banener og epler. Huske å plukke jordbær, pærer, banener og epler.Huske å plukke jordbær, pærer, banener og epler. Huske å plukke jordbær, pærer, banener og epler.  .Huske å plukke jordbær, pærer, banener og epler. Huske å plukke jordbær, pærer, banener og epler. Huske å plukke jordbær, pærer, banener og epler.', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (22, 'Bagasjen bortpå hjørnet igjen, må huskes', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (23, 'Rottegift lorem impsum lorem impusm har du det bra i dag. Jo takk som spør. Tusen takk igjen for at du spurte så fint.', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (24, 'Puser som luser.Nå er det punktum-finale nå må du pinadø smøre brødskivan di sjøl, lille pus.', '6b1087a2-2098-4cfb-bd15-e83c0e235dd3')");
        }
        
        public override void Down()
        {
        }
    }
}
