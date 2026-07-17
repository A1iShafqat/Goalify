# Goalify Agent Guidance

## Scope and sources of truth

- The production Flutter app is in `goalify_app/`.
- The MAUI solution in `Goalify/` is a read-only migration and behavior reference unless the user explicitly requests a MAUI change.
- Product and migration decisions live in `docs/`.
- For foundational Flutter work, read only the relevant sections of:
  - `docs/FRAMEWORK_DECISION_AND_TECHNICAL_DIRECTION.md`
  - `docs/FLUTTER_MIGRATION_TIMELINE.md`
- `docs/PRODUCT_UX_FLOW.md` is the approved source for product behavior and screen flow.
- For visual work, read `.stitch/DESIGN.md`; use `docs/STITCH_UI_PROMPT_PACK.md` only for Stitch generation or review.
- A direct user decision in the current task overrides an older document. Otherwise, preserve documented unresolved questions instead of inventing policy.

## Product guardrails

- User-facing concepts are **Activity**, **Routine**, and **Goal**. Goal is the selected minimum score for a dated Routine run, not a parent container.
- Activity defaults are copied into Routine-owned settings when attached. A saved Routine is reusable; each start or restart creates a separate dated run. Finalized history and results are immutable.
- The shell is **Today / Routines / More**. Routines owns Current, Saved, and History. More owns profile, settings, and tool enablement. The drawer contains enabled tool shortcuts only.
- To-Dos and standalone Reminders are MVP tools. Disabling a tool hides its shortcut without deleting data.
- Start-to-end is Complete/Done, then Undo. End-to-start is item-specific: Routine Activity Mute today, Reminder Delay, and To-Do Edit/reschedule. Every gesture needs a visible alternative.
- Completed items remain visible below incomplete items and use an accessible motivational state with an icon and label, not color alone.
- PVRD allocates Daily/Weekly/Monthly categories 60/30/10 and gives Essential Activities double shares within their category. Keep unresolved scoring edge cases unresolved until the user decides them.
- Import/export is V1.1. Gallery-image icons, Routine sharing, and analytics are future work.
- The three-week migration timeline covers prototype parity and a Flutter validation slice, not the full MVP.

## Platform-native roles

This repository supports both platforms without copying one platform's metadata into the other:

- Codex custom agents: `.codex/agents/flutter_architecture_expert.toml` and `.codex/agents/flutter_session_reviewer.toml`.
- Antigravity skills: `.agents/skills/flutter-architecture-expert/SKILL.md` and `.agents/skills/flutter-session-reviewer/SKILL.md`.
- Antigravity workspace routing: `.agents/rules/goalify.md`, which imports this file.

Use the architecture role for new Flutter features, enhancements, migration sessions, architectural changes, and substantial Flutter explanations. It must inspect the bounded scope, run the reuse/package check, present a plan, and wait for explicit approval before implementing a feature or enhancement. A genuinely localized bug may follow its narrow bug-fix path.

After implementation stops, use the separate reviewer role for every migration/development session or when the user requests review. Never run implementation and review concurrently against changing files. Critical findings block further work; missing must-haves block dependent work; overlapping systems require user confirmation.

In Codex, delegate to the named custom agent. In Antigravity, activate the corresponding skill. Do not pretend that an Antigravity skill is a Codex custom-agent manifest or that a Codex TOML field is supported by Antigravity.

## Delegation lifecycle

- Run a required agent whose result gates the next step in the foreground by default.
- Use background execution only when the user requests it or useful independent work can safely continue.
- Before background execution, tell the user which role is running, its bounded task, that it is in the background, and how completion or failure will be reported.
- Track every delegated role to a known state. Never imply completion while required work is still running.
- Relay every result and every API, permission, tool, turn-budget, cancellation, or malformed-output failure.
- If a role stops without a terminal summary, the parent creates one from confirmed evidence.
- Never silently stop after delegation.
- Role turn budgets are behavioral unless the active platform exposes a supported enforcement field. Do not invent configuration fields. Prioritize the required result and verification, keep exploration bounded, reserve capacity for the terminal report, and return `Blocked` when completion is no longer realistic.

Every agent-related parent response and every role's normal exit must finish with:

```text
Agent status: Running | Awaiting approval | Completed | Blocked | Failed | Cancelled
Summary: <concise result>
Changes: None | <created, modified, and deleted files>
Verification: <checks and results, or Not run/Not applicable with reason>
Next action: <one clear next step>
```

Use `Changes: None (planning only)` for planning without edits and `Changes: None (read-only)` for review. Report only files changed by the current task, never an already-dirty repository-wide diff. A completed review may use `Agent status: Completed` even when its verdict is `Blocked`. Do not report unrun checks as passed.

## Flutter working standards

- Keep implementation simple and understandable for a developer learning Flutter.
- Every handwritten Dart file created or substantially changed needs concise comments explaining its purpose, important Flutter concepts, and non-obvious decisions. Do not edit generated files.
- Keep business rules outside widgets and domain code independent of Flutter UI and database packages.
- Search existing code and Flutter/Dart SDK capabilities before adding a widget, service, abstraction, package, navigation/state system, or persistence system.
- Use SQLite for structured domain data, preferences for small settings, secure storage for secrets, and memory for temporary state unless an approved decision says otherwise.
- Maintain one documented owner/system per responsibility.
- Respect accessibility, semantics, touch targets, text scaling, reduced motion, Android/iOS differences, permissions, lifecycle, and profile-mode performance.

## Verification

Choose the narrowest checks that prove the current change. Full Flutter session checks, when required, run from `goalify_app/`:

- `dart format --output=none --set-exit-if-changed .`
- `flutter analyze`
- `flutter test`
- Platform build/run checks required by the migration session

Do not run application tests for documentation or agent-configuration-only changes. Never report an environment-blocked or unrun check as passing.
