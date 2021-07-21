using Dashboard.Application.Types.ViewModels;

namespace Dashboard.Application.Companies.ViewModels
{
    public class CompanyVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LoginLink { get; set; }
        public TypeVM Type { get; set; }
    }
}
