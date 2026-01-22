public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Step 1: Remove everyone to get true FIFO order
        List<Person> temp = new();
        while (!_people.IsEmpty())
        {
            temp.Add(_people.Dequeue());
        }

        // Step 2: The oldest person is the last one removed
        Person person = temp[^1];

        // Step 3: Rebuild the queue WITHOUT the selected person
        for (int i = temp.Count - 2; i >= 0; i--)
        {
            _people.Enqueue(temp[i]);
        }

        // Step 4: Handle turns
        if (person.Turns <= 0)
        {
            // Infinite turns → always re-add
            _people.Enqueue(person);
        }
        else
        {
            person.Turns--;

            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
