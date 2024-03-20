
namespace AvansDevOps.ScrumRole {
    public class User {
        public IScrumRole role;

        public void setRole(IScrumRole role) {
            this.role = role;
        }

        public void performRole() {
            role.execute();
        }
    }
}