namespace CvStorage.Core
{
    public class Interest : Entity
    {
        public string Hobby { get; set; }
        public int CvId { get; set; }
        public virtual Cv Cv { get; set; }
    }
}