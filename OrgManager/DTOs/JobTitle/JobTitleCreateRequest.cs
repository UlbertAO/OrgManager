namespace OrgManager.DTOs.JobTitle
{
    public class JobTitleCreateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
    }
}
