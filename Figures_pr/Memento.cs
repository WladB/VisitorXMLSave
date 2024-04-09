using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures_pr
{
    public interface IMemento
    {
        string GetName();

        State GetState();

        DateTime GetDate();
    }
    public struct State{
    public string FiguresCode;
    public int SelectedIndex;
        public State(string f, int s)
        {
            FiguresCode = f;
            SelectedIndex = s;
        }
    }
   public class VectorRedactorMemento : IMemento
    {
        private State _state;

        private DateTime _date;

        public VectorRedactorMemento(string stateFig, int SIndex)
        {
            this._state = new State(stateFig, SIndex);
            this._date = DateTime.Now;
        }

        public State GetState()
        {
            return this._state;
        }

        public string GetName()
        {
            return $"{this._date}";
        }

        public DateTime GetDate()
        {
            return this._date;
        }
    }
    class Caretaker
    {
        private List<IMemento> _mementos = new List<IMemento>();
        private int _currentIndex = -1;
        private Form1 _originator = null;

        public Caretaker(Form1 originator)
        {
            this._originator = originator;
        }

       
        public void Backup()
        {
            Console.WriteLine("\nCaretaker: Saving Originator's state");
            if (_currentIndex < _mementos.Count - 1)
            {
                _mementos.RemoveRange(_currentIndex + 1, _mementos.Count - (_currentIndex + 1));
            }
            IMemento memento = this._originator.Save();
            _mementos.Add(memento);
            _currentIndex++;
        }

        public void Undo()
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                IMemento memento = _mementos[_currentIndex];
                Console.WriteLine("Caretaker: Undoing state to: " + memento.GetName());
                this._originator.Restore(memento);
            }
            else
            {
                Console.WriteLine("Caretaker: Nothing to undo.");
            }
        }

        public void Redo()
        {
            if (_currentIndex < _mementos.Count - 1)
            {
                _currentIndex++;
                IMemento memento = _mementos[_currentIndex];
                Console.WriteLine("Caretaker: Redoing state to: " + memento.GetName());
                this._originator.Restore(memento);
            }
            else
            {
                Console.WriteLine("Caretaker: Nothing to redo.");
            }
        }
    }
}
