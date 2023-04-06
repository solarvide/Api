namespace App.Dto.Proposal
{
    public class ProposalResponseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WhatsApp { get; set; }
        public decimal Average { get; set; }
        public string Archive { get; set; }
        
        public List<Month> Months { get; set; } 
    }
}
