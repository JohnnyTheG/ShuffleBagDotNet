namespace ShuffleBagDotNet
{
    public class ShuffleBag<T>
    {
        /// <summary>
        /// The collection representing the bag.
        /// </summary>
        private List<T> shuffleBag = new List<T>();

        /// <summary>
        /// The initial set of values in the shuffle bag.
        /// </summary>
        private IEnumerable<T> initialValues;

        /// <summary>
        /// Whether the bag should automatically refill once everything is selected from it.
        /// </summary>
        private bool refillWhenEmpty;

        /// <summary>
        /// Random 
        /// </summary>
        private Random random;

        /// <summary>
        /// Whether the shuffle bag is empty of not.
        /// </summary>
        public bool IsEmpty { get { return shuffleBag.Count == 0; } }

        /// <summary>
        /// Initialise the bag for use.
        /// </summary>
        /// <param name="values"></param>
        public ShuffleBag(IEnumerable<T> values, bool refillWhenEmpty)
        {
            initialValues = values;

            this.refillWhenEmpty = refillWhenEmpty;

            shuffleBag.AddRange(values);

            // Initialise the random instance with a unique guid.
            random = new Random(Guid.NewGuid().GetHashCode());
        }

        /// <summary>
        /// Refill the bag back to its initial state (filled with the set of initial values).
        /// </summary>
        public void Refill()
        {
            shuffleBag.Clear();

            shuffleBag.AddRange(initialValues);
        }

        /// <summary>
        /// Get selection from the shuffle bag.
        /// </summary>
        /// <returns></returns>
        public T Next()
        {
            if (shuffleBag.Count == 0)
            {
                if (refillWhenEmpty)
                {
                    Refill();
                }
                else
                {
                    throw new ShuffleBagEmptyException("Shuffle Bag is empty. Call or enable refillWhenEmpty in constructor.");
                }
            }

            int index = random.Next(shuffleBag.Count);

            T selection = shuffleBag[index];

            shuffleBag.RemoveAt(index);

            return selection;
        }
    }
}
