using System;
using System.Collections.Generic;

namespace AllergyScore
{
    /// <summary>
    /// Encapsulate the information about allergy test score and its analysis.
    /// </summary>
    public class Allergies
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Allergies"/> class with test score.
        /// </summary>
        /// <param name="score">The allergy test score.</param>
        /// <exception cref="ArgumentException">Thrown when score is less than zero.</exception>
        private readonly int score;

        public Allergies(int score)
        {
            if (score < 0)
            {
                throw new ArgumentException($"Size of matrix '{score}' cannot be less than zero.");
            }

            this.score = score;
        }

        /// <summary>
        /// Determines on base on the allergy test score for the given person, whether or not they're allergic to a given allergen(s).
        /// </summary>
        /// <param name="allergens">Allergens.</param>
        /// <returns>true if there is an allergy to this allergen, false otherwise.</returns>
        public bool IsAllergicTo(Allergens allergens)
        {
            if (((Allergens)this.score & allergens) != 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines the full list of allergies of the person with given allergy test score.
        /// </summary>
        /// <returns>Full list of allergies of the person with given allergy test score.</returns>
        public Allergens[] AllergensList()
        {
            int st = 0b01;
            var list = new List<Allergens>();
            while (st <= 128)
            {
                if ((st & this.score) != 0)
                {
                    list.Add((Allergens)st);
                }

                st <<= 1;
            }

            return list.ToArray();
        }
    }
}
