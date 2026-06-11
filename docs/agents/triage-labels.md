# Triage Labels

The skills speak in terms of five canonical triage roles. This file maps those roles to the actual label strings used in this repo's issue tracker.

| Label in mattpocock/skills | Label in our tracker | Meaning                                  | TH
| -------------------------- | -------------------- | ---------------------------------------- |
| `needs-triage`             | `needs-triage`       | Maintainer needs to evaluate this issue  | รอ maintainer ประเมิน
| `needs-info`               | `needs-info`         | Waiting on reporter for more information | รอข้อมูลจากคนแจ้ง
| `ready-for-agent`          | `ready-for-agent`    | Fully specified, ready for an AFK agent  | spec ครบ agent หยิบทำได้เลย
| `ready-for-human`          | `ready-for-human`    | Requires human implementation            | ต้องให้คนทำ
| `wontfix`                  | `wontfix`            | Will not be actioned                     | จะไม่ทำ

In the local-markdown tracker there are no GitHub-style labels — the role string is written on the `Status:` line near the top of each issue file (see `issue-tracker.md`).

When a skill mentions a role (e.g. "apply the AFK-ready triage label"), use the corresponding label string from this table.

Edit the right-hand column to match whatever vocabulary you actually use.
