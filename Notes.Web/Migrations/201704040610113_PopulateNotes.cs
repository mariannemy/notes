namespace Notes.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNotes : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT notes ON");

            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (1, 'Husk katten', '9fc069da-a4b5-4c85-ac68-021ea2e7462a')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (2, 'Husk bikkja fra januar og frem til mars', '9fc069da-a4b5-4c85-ac68-021ea2e7462a')");
            Sql("INSERT INTO notes(NoteId, Text, UserId) VALUES (3, 'vaffeldag i morra', '0010b80d-17fd-4c77-bb90-2378b7661cdf')");
        }
        
        public override void Down()
        {
        }
    }
}
