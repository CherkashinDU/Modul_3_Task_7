using System.Collections.Generic;

namespace Contacts
{
    public class ContactFullNameComparer : IComparer<Contact>
    {
        public int Compare(Contact x, Contact y)
        {
            return x.FullName.ToLowerInvariant().CompareTo(y.FullName.ToLowerInvariant());
        }
    }
}
