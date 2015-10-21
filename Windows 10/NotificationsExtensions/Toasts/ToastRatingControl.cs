using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions.Toasts
{
    /// <summary>
    /// The toast star rating selection.
    /// </summary>
    public enum ToastRating
    {
        /// <summary>
        /// One star (the lowest rating).
        /// </summary>
        OneStar,

        /// <summary>
        /// Two stars.
        /// </summary>
        TwoStars,

        /// <summary>
        /// Three stars.
        /// </summary>
        ThreeStars,

        /// <summary>
        /// Four stars.
        /// </summary>
        FourStars,

        /// <summary>
        /// Five stars (the highest rating).
        /// </summary>
        FiveStars
    }

    /// <summary>
    /// A rating control, which lets users pick a 1 to 5 star rating.
    /// </summary>
    public sealed class ToastRatingControl : IToastInput
    {
        /// <summary>
        /// Initializes a new rating control with the required elements.
        /// </summary>
        /// <param name="id">Developer-provided ID that the developer uses later to retrieve input when the toast is interacted with.</param>
        /// <param name="oneStarContent">Text interpretation of a one-star selection. Used for fallback purposes on builds that don't support rating control (a selection box with this text is displayed instead).</param>
        /// <param name="twoStarContent">>Text interpretation of a two-star selection. Used for fallback purposes on builds that don't support rating control (a selection box with this text is displayed instead).</param>
        /// <param name="threeStarContent">>Text interpretation of a three-star selection. Used for fallback purposes on builds that don't support rating control (a selection box with this text is displayed instead).</param>
        /// <param name="fourStarContent">>Text interpretation of a four-star selection. Used for fallback purposes on builds that don't support rating control (a selection box with this text is displayed instead).</param>
        /// <param name="fiveStarContent">>Text interpretation of a five-star selection. Used for fallback purposes on builds that don't support rating control (a selection box with this text is displayed instead).</param>
        public ToastRatingControl(string id, string oneStarContent, string twoStarContent, string threeStarContent, string fourStarContent, string fiveStarContent)
        {
            if (id == null)
                throw new ArgumentNullException("id");

            if (oneStarContent == null)
                throw new ArgumentNullException("oneStarContent");

            if (twoStarContent == null)
                throw new ArgumentNullException("twoStarContent");

            if (threeStarContent == null)
                throw new ArgumentNullException("threeStarContent");

            if (fourStarContent == null)
                throw new ArgumentNullException("fourStarContent");

            if (fiveStarContent == null)
                throw new ArgumentNullException("fiveStarContent");

            Id = id;
            OneStarContent = oneStarContent;
            TwoStarContent = twoStarContent;
            ThreeStarContent = threeStarContent;
            FourStarContent = fourStarContent;
            FiveStarContent = fiveStarContent;
        }

        /// <summary>
        /// The ID property is required, and is used so that developers can retrieve user input once the app is activated.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Text interpretation of a one-star selection. Used for fallback purposes on builds that don't support rating control (a selection box with this text is displayed instead).
        /// </summary>
        public string OneStarContent { get; private set; }

        /// <summary>
        /// Text interpretation of a two-star selection. Used for fallback purposes on builds that don't support rating control (a selection box with this text is displayed instead).
        /// </summary>
        public string TwoStarContent { get; private set; }

        /// <summary>
        /// Text interpretation of a three-star selection. Used for fallback purposes on builds that don't support rating control (a selection box with this text is displayed instead).
        /// </summary>
        public string ThreeStarContent { get; private set; }

        /// <summary>
        /// Text interpretation of a four-star selection. Used for fallback purposes on builds that don't support rating control (a selection box with this text is displayed instead).
        /// </summary>
        public string FourStarContent { get; private set; }

        /// <summary>
        /// Text interpretation of a five-star selection. Used for fallback purposes on builds that don't support rating control (a selection box with this text is displayed instead).
        /// </summary>
        public string FiveStarContent { get; private set; }

        /// <summary>
        /// Title text to display above the rating control.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The initial rating to use (or leave null to have the control start with no stars selected).
        /// </summary>
        public ToastRating? DefaultRating { get; set; }
        

        internal Element_ToastInput ConvertToElement()
        {
            return new Element_ToastInput()
            {
                Id = Id,
                Type = ToastInputType.Selection,
                DefaultInput = DefaultRating == null ? null : ConvertToId(DefaultRating.Value),
                Title = Title,
                SelectionType = "rating",
                Children =
                {
                    new Element_ToastSelection()
                    {
                        Id = "0.2",
                        Content = OneStarContent
                    },

                    new Element_ToastSelection()
                    {
                        Id = "0.4",
                        Content = TwoStarContent
                    },

                    new Element_ToastSelection()
                    {
                        Id = "0.6",
                        Content = ThreeStarContent
                    },

                    new Element_ToastSelection()
                    {
                        Id = "0.8",
                        Content = FourStarContent
                    },

                    new Element_ToastSelection()
                    {
                        Id = "1.0",
                        Content = FiveStarContent
                    }
                }
            };
        }

        private static string ConvertToId(ToastRating rating)
        {
            switch (rating)
            {
                case ToastRating.OneStar:
                    return "0.2";

                case ToastRating.TwoStars:
                    return "0.4";

                case ToastRating.ThreeStars:
                    return "0.6";

                case ToastRating.FourStars:
                    return "0.8";

                case ToastRating.FiveStars:
                    return "1.0";

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
