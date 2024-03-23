﻿using AvansDevOps.Backlog;
using AvansDevOps.ScrumRole;
using AvansDevOps.Sprint.SprintState;

namespace AvansDevOps.Sprint {
    public abstract class Sprint {
        public List<User> Developers { get; } = new();
        public User? Smaster { get; set; }
        public List<BacklogItem> BacklogItems { get; } = new();
        public string Name { get; set; }
        private MainState State { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public Sprint(string name) { 
            Name = name;
            State = new CreatedState();
        }

        public abstract void SprintEnded();

        private bool CheckDevRole(User user) {
            if (user.GetRole() is not Developer) throw new ArgumentException("User should have the role of Developer");
            return true;
        }
        private bool CheckScrummasterRole(User user) {
            if (user.GetRole() is not Scrummaster) throw new ArgumentException("User should have the role of Scrummaster");
            return true;
        }
        public void AddMember(User member) {
            if (CheckDevRole(member)) Developers.Add(member);
        }
        public void RemoveMember(User member) {
            if (CheckDevRole(member)) Developers.Remove(member);
        }
        public void SetScrummaster(User scrummaster) {
            if(CheckScrummasterRole(scrummaster)) Smaster = scrummaster;
        }
        public void ChangeSprintName(string name) {
            State.ChangeSprintName(this, name);
        }
        public void AddBacklogItems(BacklogItem item) {
            State.AddBacklogItems(this, item);
        }
        public void SetStartAndEndDate(DateOnly startDate, DateOnly endDate) {
            State.SetStartAndEndDate(this, startDate, endDate);
        }
        public void StartSprint() {
            State.StartSprint(this);
        }
        public void EndSprint() {
            State.EndSprint(this);
        }
        public void SetState(MainState state) {
            State = state;
        }
    }
}
