/*
Agenda:
    [X] Delegates
    [X] Action, Func and Predicate
    [X] Anonymous delegates / Lambda expressions
    [X] Events
*/

using Events.Examples;
using Events.Exercises;

class Program
{
    static void Main(string[] args)
    {
        ReduceArray.Run2();
    }
}

// Delegates allow us to treat methods as data.
// Lambda expressions allow us to create methods on the fly
// Events implements an observable/observer pattern allowing us to decouple the emitter of a message from
// the consumer of the message
// 
 