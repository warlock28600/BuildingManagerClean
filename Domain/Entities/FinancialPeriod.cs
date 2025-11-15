using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class FinancialPeriod : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        #region Navigation Properties
        public ICollection<Expense> Expenses { get; set; }
        #endregion

    }
}
