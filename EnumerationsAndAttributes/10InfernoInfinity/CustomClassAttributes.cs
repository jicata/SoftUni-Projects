namespace _10InfernoInfinity
{
    using System;
    using System.Collections.Generic;

    public class CustomClassAttributes : Attribute
    {

        private string author;
        private int revision;
        private string description;
        private List<string> reviewers;

        public CustomClassAttributes(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.reviewers = new List<string>();
            AddReviewers(reviewers);
        }

        private void AddReviewers(string[] reviewers)
        {
            foreach (var reviewer in reviewers)
            {
                this.reviewers.Add(reviewer);
            }
        }


        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public int Revision
        {
            get
            {
                return revision;
            }

            set
            {
                revision = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public List<string> Reviewers
        {
            get
            {
                return reviewers;
            }
        }

    }
}
