# Goalify Chat Context

Last reviewed: 2026-07-22

## Purpose

This is the durable onboarding and handoff file for a new Goalify chat with no
prior conversation history. Read the repository-root `AGENTS.md` first, then
this file. Use it to become oriented quickly; it does not replace the live
repository or the authoritative documents listed below.

At the start of work:

1. Check the current Git status and inspect the relevant code. Preserve existing
   user changes.
2. Read only the source-of-truth sections relevant to the request.
3. Treat a direct current-task user decision as newer than this file.
4. If this summary conflicts with current code or an authoritative document,
   follow the authoritative source and update this context when appropriate.

## Project in one paragraph

Goalify is an offline-first, privacy-first routine tracker designed to reward
consistency without guilt or fragile daily streaks. The production target is
Flutter in `goalify_app/`. The older .NET MAUI solution in `Goalify/` is a
read-only behavior and migration reference unless the user explicitly requests
a MAUI change. The approved product language is **Activity**, **Routine**, and
**Goal**.

The user is experienced with C#, Xamarin, .NET MAUI, XAML, MVVM, dependency
injection, SQLite, and mobile development, and is learning Flutter. Explain the
Flutter concept first. Use a short MAUI comparison only when it is accurate and
helpful. Prefer simple, readable Flutter over unnecessary abstraction.

## Source-of-truth map

| Concern | Authoritative source |
| --- | --- |
| Repository scope, approval gates, agent routing, verification | `AGENTS.md` |
| Product behavior, navigation, screen flows, release boundaries | `docs/PRODUCT_UX_FLOW.md` |
| Visual tokens, components, motion direction | `.stitch/DESIGN.md` |
| Technical direction and Flutter architecture | `docs/FRAMEWORK_DECISION_AND_TECHNICAL_DIRECTION.md` |
| Three-week Flutter validation slice and session gates | `docs/FLUTTER_MIGRATION_TIMELINE.md` |
| Agent test selection and finalization policy | `docs/AGENT_TESTING_STRATEGY.md` |
| Stitch generation and review prompts only | `docs/STITCH_UI_PROMPT_PACK.md` |

Do not use the Stitch prompt pack as product policy. Do not treat the migration
timeline as the complete MVP schedule; it covers prototype parity and a Flutter
validation slice.

## Approved product model

### Activity

An Activity is a reusable identity such as Walk, Read, or Stretch. It stores a
name, description, built-in icon, and visible default configuration. When added
to a Routine, its defaults are copied into settings owned by that Routine. The
Routine copy can change without changing the Activity definition.

### Routine

A Routine is a reusable definition containing configured Activities. Each start
or restart creates a separate dated run with required dates, an Activity/config
snapshot, a Goal, completion history, and Results. Editing a saved Routine
affects future runs only unless an approved flow explicitly edits an active run.
Finalized history and Results are immutable.

### Goal and Results

A Goal is the minimum score target for one dated Routine run. It is not a parent
container or separately created plan. Results are produced at the end of a run
and preserve the final score, breakdown, calendar state, Goal outcome, and
supportive message.

## Navigation and interaction decisions

- Bottom navigation is exactly **Today / Routines / More**.
- Routines owns Current, Saved, and History.
- More owns profile, tool management, settings, notifications, accessibility,
  scoring explanation, privacy, and about.
- The drawer contains enabled tool shortcuts only. It does not duplicate
  primary destinations.
- To-Dos and standalone Reminders are MVP tools. Disabling a tool hides its
  shortcut without deleting its data.
- Start-to-end gestures use Complete/Done, followed by Undo.
- End-to-start actions are item-specific: Routine Activity Mute today, Reminder
  Delay, and To-Do Edit/reschedule.
- Every gesture needs a visible alternative.
- Completed items remain visible below incomplete items and use an icon and
  label, not color alone.
- Root screens show the drawer button; child screens show Back. Do not show both
  at once.

## Product scope

MVP includes onboarding/local profile, Today, Activities, reusable Routines,
dated runs, History and immutable Results, Goal score target, PVRD scoring,
To-Dos, Reminders, local notifications, tool visibility, accessibility,
light/dark themes, and reduced motion.

V1.1 contains local import/export and backup/restore compatibility. Routine
sharing, gallery-image Activity icons, expanded analytics, social features, AI,
advertising, and premium features are future work and must not appear as
inactive MVP controls.

## Scoring baseline and unresolved decisions

PVRD allocates Daily/Weekly/Monthly categories 60/30/10. Essential Activities
receive double shares within their category. Do not invent answers for these
still-open rules:

1. Empty category behavior.
2. Whether completion above target is capped or rewarded.
3. Partial cycles at Routine start and end.
4. Mid-run changes to criteria or Essential status.
5. Backdated completions and finalized Results.
6. Week-start preference.
7. Time-zone and daylight-saving behavior.
8. Final-score rounding.

Ask the user before implementation when one of these decisions materially
affects the feature.

## Visual direction

The direction is calm motivational productivity: primary `#30A1C9`, accessible
light and dark tokens, rounded cards, generous spacing, friendly iconography,
restrained celebrations, and semantic status colors paired with icons or text.
Avoid childish gamification, shame, aggressive streak language, decorative
clutter, excessive gradients, or color-only meaning.

## Current implementation snapshot

This section is a convenience snapshot, not an authoritative live inventory.
Verify it against the code before planning or editing.

As reviewed on 2026-07-22, `goalify_app/` is an early Flutter learning scaffold:

- It currently renders a school/class-roster demo rather than Goalify product
  screens.
- `provider` supplies a mock school service and `ClassController`.
- `go_router` has one `/` route to `ClassScreen`.
- The app contains sample teacher/student models, school strings, and an enroll
  action.
- There is no Goalify Activity/Routine/run/Results domain implementation,
  persistence foundation, scoring engine, or production navigation shell yet.
- Dependencies are currently minimal: Flutter, Cupertino Icons, Provider, and
  GoRouter.
- The existing widget test belongs to the scaffold; inspect it before relying
  on it.

Do not silently rename the demo into Goalify or preserve its school-domain
architecture as product architecture. For a requested product feature, inspect
the validation timeline and propose the smallest coherent foundation or slice.

## Architecture guardrails

- Keep business rules in pure Dart and outside widgets and database packages.
- Keep SQL, scoring, recurrence, and notification policy out of widgets.
- Use stable IDs, explicit ownership, versioned migrations, and atomic writes.
- Use SQLite for structured domain data, preferences for small settings, secure
  storage for secrets, and memory for temporary UI state unless an approved
  decision says otherwise.
- Maintain one documented owner/system for navigation, state, persistence, API,
  notifications, logging, analytics, caching, dependency injection, IDs,
  serialization, validation, errors, design tokens, and clocks.
- Make local dates, time zones, DST, week start, rollover, lifecycle, and
  notification behavior explicit where relevant.
- Preserve accessibility semantics, visible gesture alternatives, touch
  targets, text scaling, contrast, reduced motion, Android/iOS differences, and
  profile-mode performance evidence where required.
- Search existing code and Flutter/Dart SDK support before adding packages or
  abstractions.
- Add concise purpose and concept comments to handwritten Dart files created or
  substantially changed. Do not edit generated files.

## Required development workflow

Features and enhancements are plan-first:

1. Inspect the request, relevant product/technical sources, existing code,
   reusable pieces, packages, and Flutter/Dart SDK support.
2. Present a bounded plan and wait for explicit approval before editing
   application code, packages, migrations, or generated configuration.
3. Implement the smallest coherent draft without adding or running behavioral
   tests.
4. Run only formatting, lint, syntax/type/import checks, and targeted static
   analysis.
5. Hand off as `Awaiting user verification` with exact manual checks.
6. Apply corrections and repeat user verification.
7. Add/update/run behavioral tests only when the user confirms the behavior or
   asks to proceed with tests.
8. Follow `docs/AGENT_TESTING_STRATEGY.md` for coverage inventory, test budget,
   layer ownership, consolidation, efficient execution, and reporting.
9. Use the independent read-only reviewer only after implementation is stable,
   or earlier when the user explicitly requests a provisional review.

A proven localized bug may use the narrow bug-fix path and proportional
regression testing when its behavior and root cause are established and no
package, migration, architecture change, broad refactor, or new behavior is
required.

## Agent platforms

- Codex adapters: `.codex/agents/flutter_architecture_expert.toml` and
  `.codex/agents/flutter_session_reviewer.toml`.
- Antigravity roles: `.agents/skills/flutter-architecture-expert/SKILL.md`,
  `.agents/skills/flutter-session-reviewer/SKILL.md`, and
  `.agents/rules/goalify.md`.
- Shared cross-platform behavior belongs in `AGENTS.md` and shared reference
  documents. Keep platform-native adapters concise; do not copy unsupported
  metadata between platforms.
- The architecture role owns test finalization. There is intentionally no
  separate testing agent; the reviewer verifies test quality.

## Verification expectations

Choose the narrowest checks allowed by the current workflow stage. Application
tests are not required for documentation or agent-configuration-only changes.
After explicit test-finalization approval, full session checks run from
`goalify_app/` when the change requires them:

```text
dart format --output=none --set-exit-if-changed .
flutter analyze
flutter test
```

Add platform build/run or physical-device checks when the session or risk
requires them. Never report an unrun, blocked, or noisy-failing check as passed.

## New-chat startup checklist

For a new Goalify request:

1. Read `AGENTS.md` and this file.
2. Run a scoped Git status check and protect existing changes.
3. Classify the request: feature, enhancement, localized bug, review, or
   explanation.
4. Open only the relevant authoritative document sections and code paths.
5. Confirm whether the request affects an unresolved scoring/date policy.
6. Use the architecture role for implementation work and the read-only reviewer
   only at the correct stable stage.
7. Report exact task changes and verification with the terminal status block
   required by `AGENTS.md`.
