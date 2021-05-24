namespace Hospital.Dtos
{
    public class DoctorCreateDto //Created the doctorobject as a Data Trasfer Object so the client doesn´t get the internal object but this instead. Which gives the porperties to the call need instead of everything.
    {
        public int DoctorId {get; set;} //This should not be here when using a database. It will supply it for us
                                        
        public string Name { get; set; }

        public string Department {get; set;}
    }
}