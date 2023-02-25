using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Person
    {

        public string Avatar { get; set; }
        public string FullName { get; set; }

        public DateTime date { get; set; }

        public ObservableCollection<Conversation> ConversationList { get; set; } = new();

    }
}
