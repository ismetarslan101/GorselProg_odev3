using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalOdevHazirlikMaui.Models
{
    public class Notes : INotifyPropertyChanged
    {

        public Notes()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now; // Varsayılan olarak şu anki zamanı ayarlar
        }
        private string noteContent,id;
        private bool isCompleted;
        private DateTime createdAt;


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public string Id
        {
            get
            {
                if (id == null)
                    id = Guid.NewGuid().ToString();
                return id;
            }
            set { id = value; }
        }

        public string NoteContent
        {
            get{ return noteContent; }
            set
            {
                noteContent = value;
                OnPropertyChanged();
            }

        }

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set
            {
                createdAt = value;
                OnPropertyChanged();
            }
        }

        public bool IsCompleted
        {
            get { return isCompleted; }
            set
            {
                isCompleted = value;
                OnPropertyChanged();
            }
        }

        
    }
}
