using System.Linq;
using Redux;

namespace DotNetReduxExample
{
    public class CombinedReducer<TState>
    {
        private readonly Reducer<TState>[] _reducers;

        public CombinedReducer(params Reducer<TState>[] reducers)
        {
            _reducers = reducers;
        }

        public TState Execute(TState current, IAction action)
            => _reducers.Aggregate(current, (c, reducer) => reducer(c, action));
    }
}