using CPT231_Assignment06_LeviNoell_Baba.Models;

namespace CPT231_Assignment06_LeviNoell_Baba.Models
{
    public class MagicSession//class to manage session data related to magic items
    {
        //constants for session keys
        private const string MagicsKey = "mymagic";
        private const string CountKey = "magiccount";

        //session object for storing session data
        private ISession session { get; set; }
        public MagicSession(ISession session) => this.session = session;//constructor to initialize with an isession object
        //method to set a list of magic items in the session
        public void SetMyMagics(List<Magic> magics) {
            session.SetObject(MagicsKey, magics);
            session.SetInt32(CountKey, magics.Count);
        }
        public List<Magic> GetMyMagics() =>//method to retrieve the list of magic items from the session
            session.GetObject<List<Magic>>(MagicsKey) ?? new List<Magic>();
        public int? GetMyMagicCount() => session.GetInt32(CountKey);

        //method to remove the list of magic items and its count from the session.
        public void RemoveMyMagics() {
            session.Remove(MagicsKey);
            session.Remove(CountKey);
        }
    }
}