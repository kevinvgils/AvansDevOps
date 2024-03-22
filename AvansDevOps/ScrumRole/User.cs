
namespace AvansDevOps.ScrumRole {
    public class User {
        private IScrumRole role;

        public User(IScrumRole role) {
            this.role = role;
        }

        public void SetRole(IScrumRole role) {
            this.role = role;
        }

        public IScrumRole GetRole() {
            return role;
        }

        public void PerformRole() {
            role.execute();
        }
    }
}