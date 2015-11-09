namespace JediMeditation
{
    using System;

    public abstract class Jedi : IJedi
    {

        public Jedi(string jediName)
        {
            this.Name = jediName;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
