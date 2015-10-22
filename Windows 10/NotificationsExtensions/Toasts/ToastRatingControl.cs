using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace NotificationsExtensions.Toasts
{
    /// <summary>
    /// A rating control, which lets users pick a one to five star rating. Selection value is returned as a string that is a float, 0.0 - 1.0.
    /// </summary>
    public sealed class ToastRatingControl : IToastInput
    {
        private static readonly float[] FLOAT_VALUES = new float[] { 0.0f, 0.2f, 0.4f, 0.6f, 0.8f, 1.0f };

        /// <summary>
        /// Use this to parse the rating response from a toast rating control. Returns a float of either 0.0, 0.2, 0.4, 0.6, 0.8 or 1.0. Throws exception if userInputValue is not a string, or not able to parse to a float, or not one of the valid float values.
        /// </summary>
        /// <param name="userInputValue">The value retrieved from ToastNotificationActivatedEventArgs.UserInput[id], where id is the id of a rating control.</param>
        /// <returns></returns>
        public static float ParseRating(object userInputValue)
        {
            // In legacy cases with the selection box, the selected value is null when not selected
            if (userInputValue == null)
                return 0.0f;

            string str = userInputValue as string;

            if (str == null)
                throw new ArgumentException("userInputValue must be a string.");

            float parsed = float.Parse(str);

            if (!FLOAT_VALUES.Contains(parsed))
                throw new ArgumentException("userInputValue wasn't one of the accepted rating values (it was " + userInputValue + ").");

            return parsed;
        }

        /// <summary>
        /// Text interpretations of star selections. Used for fallback purposes on builds that don't support rating control (a selection box with these text elements is displayed instead). You must provide a collection of exactly 5 initialized strings.
        /// </summary>
        public IEnumerable<string> AltContents { get; private set; }

        /// <summary>
        /// Initializes a new rating control with the required elements.
        /// </summary>
        /// <param name="id">Developer-provided ID that the developer uses later to retrieve input when the toast is interacted with.</param>
        /// <param name="altContents">Text interpretations of star selections. Used for fallback purposes on builds that don't support rating control (a selection box with these text elements is displayed instead). You must provide a collection of exactly 5 initialized strings.</param>
        public ToastRatingControl(string id, IEnumerable<string> altContents)
        {
            if (id == null)
                throw new ArgumentNullException("id");

            if (altContents == null)
                throw new ArgumentNullException("altContents");

            Id = id;

            List<string> copied = new List<string>();

            foreach (string s in altContents)
            {
                if (copied.Count >= 5)
                    throw new ArgumentException("altContents must contain exactly 5 strings, you provided too many.");

                if (s == null)
                    throw new NullReferenceException("altContents cannot contain null strings.");

                copied.Add(s);
            }

            if (copied.Count < 5)
                throw new ArgumentException("altContents must contain exactly 5 strings, you provided too few.");
            
            AltContents = new ReadOnlyCollection<string>(copied);
        }

        /// <summary>
        /// The ID property is required, and is used so that developers can retrieve user input once the app is activated.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Title text to display above the rating control.
        /// </summary>
        public string Title { get; set; }

        private float _defaultRating;
        /// <summary>
        /// The initial rating to use. The default value is 0.0, which means unselected. Valid values are 0.0, 0.2, 0.4, 0.6, 0.8, and 1.0.
        /// </summary>
        public float DefaultRating
        {
            get { return _defaultRating; }
            set
            {
                if (!FLOAT_VALUES.Contains(value))
                    throw new ArgumentException("DefaultRating can only be 0.0, 0.2, 0.4, 0.6, 0.8, or 1.0");

                _defaultRating = value;
            }
        }
        

        internal Element_ToastInput ConvertToElement()
        {
            return new Element_ToastInput()
            {
                Id = Id,
                Type = ToastInputType.Selection,
                DefaultInput = DefaultRating == 0f ? null : ConvertToId(DefaultRating),
                Title = Title,
                SelectionType = "rating",
                Children =
                {
                    new Element_ToastSelection()
                    {
                        Id = ConvertToId(0.2f),
                        Content = AltContents.ElementAt(0)
                    },

                    new Element_ToastSelection()
                    {
                        Id = ConvertToId(0.4f),
                        Content = AltContents.ElementAt(1)
                    },

                    new Element_ToastSelection()
                    {
                        Id = ConvertToId(0.6f),
                        Content = AltContents.ElementAt(2)
                    },

                    new Element_ToastSelection()
                    {
                        Id = ConvertToId(0.8f),
                        Content = AltContents.ElementAt(3)
                    },

                    new Element_ToastSelection()
                    {
                        Id = ConvertToId(1.0f),
                        Content = AltContents.ElementAt(4)
                    }
                }
            };
        }

        private static string ConvertToId(float rating)
        {
            if (rating == 0.2f)
                return "0.200000";

            if (rating == 0.4f)
                return "0.400000";

            if (rating == 0.6f)
                return "0.600000";

            if (rating == 0.8f)
                return "0.800000";

            if (rating == 1.0f)
                return "1.000000";


            throw new NotImplementedException("Rating: " + rating);
        }
    }
}
