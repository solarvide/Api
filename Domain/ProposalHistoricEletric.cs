using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProposalHistoricEletric : BaseEntityWithId
    {
        [ForeignKey("proposalId")]
        public Proposal proposal { get; set; }
        public long  proposalId { get; set; }  
        public string Month { get; set; }
        [MaxLength(4000)]
        public decimal Value { get; set; }
    }
}
