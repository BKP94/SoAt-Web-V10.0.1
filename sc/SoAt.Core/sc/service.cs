namespace sc
{
    // CHANGED: was service(sc.page page) — sc.page is ASP.NET Web Forms, replaced with sc.db injection
    public class service
    {
        protected sc.db db { get; private set; }
        public service(sc.db db) => this.db = db;
    }
}
