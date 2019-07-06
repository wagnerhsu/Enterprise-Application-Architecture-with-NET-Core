using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applications.Model
{
    /// <summary>
    /// DocumentValidity class maps directly to the entity in the database (relational)
    /// </summary>
    public class DocumentValidity
    {
        [Key, Column(Order = 1)]
        public int Employee_ID { get; set; }
        //[Key, Column(Order = 2)] //DataAnotation is not working for composite key, other is to use the fluent api
        public int DOC_ID { get; set; }
        public DateTime DOC_Issue_Date { get; set; }
        public DateTime DOC_Expiry_Date { get; set; }
        public byte[] DOC_Data { get; set; }
    }
}
