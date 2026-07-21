# Goalify Agent Guidance

## Scope and sources of truth

- The production Flutter app is in `goalify_app/`.
- The MAUI solution in `Goalify/` is a read-only migration and behavior reference
  unless the user explicitly requests a MAUI change.
- Product and migration decisions live in `docs/`.
- Foundational Flutter work may use only relevant sections of
  `docs/FRAMEWORK_DECISION_AND_TECHNICAL_DIRECTION.md` and
  `docs/FLUTTER_MIGRATION_TIMELINE.md`.
- `docs/PRODUCT_UX_FLOW.md` is the approved source for product behavior and screen flow.
- At the start of a new Goalify chat, or whenever prior project context is
  missing, read `docs/GOALIFY_CHAT_CONTEXT.md` for a concise project handoff;
  verify its implementation snapshot against the live repository.
- `docs/AGENT_TESTING_STRATEGY.md` is the shared policy for test selection,
  ownership, consolidation, execution, and review across both agent platforms.
- For visual work, read `.stitch/DESIGN.md`; use
  `docs/STITCH_UI_PROMPT_PACK.md` only for Stitch generation or review.
- A direct current-task user decision overrides an older document. Otherwise,
  preserve documented unresolved questions instead of inventing policy.
- Load only the source sections and code paths relevant to the task. Prefer
  targeted search over repository-wide or full-document rereads.

## Product guardrails

- User-facing concepts are **Activity**, **Routine**, and **Goal**. Goal is the
  selected minimum score for a dated Routine run, not a parent container.
- Activity defaults are copied into Routine-owned settings when attached. A
  saved Routine is reusable; each start or restart creates a separate dated
  run. Finalized history and results are immutable.
- The shell is **Today / Routines / More**. Routines owns Current, Saved, and
  History. More owns profile, settings, and tool enablement. The drawer contains
  enabled tool shortcuts only.
- To-Dos and standalone Reminders are MVP tools. Disabling a tool hides its
  shortcut without deleting data.
- Start-to-end is Complete/Done, then Undo. End-to-start is item-specific:
  Routine Activity Mute today, Reminder Delay, and To-Do Edit/reschedule. Every
  gesture needs a visible alternative.
- Completed items remain visible below incomplete items and use an accessible
  motivational state with an icon and label, not color alone.
- PVRD allocates Daily/Weekly/Monthly categories 60/30/10 and gives Essential
  Activities double shares within their category. Keep unresolved scoring edge
  cases unresolved until the user decides them.
- Import/export is V1.1. Gallery-image icons, Routine sharing, and analytics are
  future work.
- The three-week migration timeline covers prototype parity and a Flutter
  validation slice, not the full MVP.

## Platform-native roles

Keep each platform in its native format:

- Codex: `.codex/agents/flutter_architecture_expert.toml` and
  `.codex/agents/flutter_session_reviewer.toml`.
- Antigravity: `.agents/skills/flutter-architecture-expert/SKILL.md`,
  `.agents/skills/flutter-session-reviewer/SKILL.md`, and
  `.agents/rules/goalify.md`.

Use the architecture role for Flutter features, enhancements, migration
sessions, architectural changes, localized bug fixes, and substantial
explanations. Features and enhancements require a bounded reuse/package check,
a plan, and explicit implementation approval. A genuinely localized bug may
use its narrow bug-fix path.

Use the independent reviewer after user verification and test finalization stop,
or earlier when the user explicitly requests review. An early review is
provisional. Never review concurrently with changing files. In Codex delegate
to the named custom agent; in Antigravity activate the matching skill. Do not
copy Codex fields or handoff mechanisms into Antigravity metadata.

Do not create a separate testing agent. Test finalization remains with the
architecture role, and the reviewer verifies test quality against
`docs/AGENT_TESTING_STRATEGY.md`. Reconsider only if testing becomes a frequent,
substantial workflow with clearly separate ownership and fewer handoffs.

## Delegation lifecycle

- Run a gating role in the foreground by default. Use background execution only
  when the user requests it or independent work can safely continue.
- Before background execution, state the role, bounded task, that it is
  background work, and how completion or failure will be reported.
- Track every delegated role to a known state. Never imply completion while a
  required role is running, and never silently stop after delegation.
- Relay every result and every API, permission, tool, turn-budget,
  cancellation, and malformed-output failure.
- If a role stops without a terminal summary, the parent creates one from
  confirmed evidence.
- Turn budgets are behavioral unless the platform documents a native field. Do
  not invent one. Stay in scope, prioritize the required outcome, reserve
  capacity for the handoff, and return `Blocked` when completion is no longer
  realistic.
- Use moderate reasoning by default. Raise effort only for genuinely complex
  architecture, security, migration, or unresolved-defect work.

Every agent-related parent response and every role's normal exit, including an
approval wait, user-verification wait, question, success, review, localized bug
fix, block, interruption, or cancellation, must end with this block and nothing
after it:

```text
Agent status: Running | Awaiting approval | Awaiting user verification | Completed | Blocked | Failed | Cancelled
Summary: <concise result>
Changes: None | <created, modified, and deleted files>
Verification: <checks and results, or Not run/Not applicable with reason>
Test count: <before -> after, or Not applicable>
Next action: <one clear next step>
```

Use `Awaiting approval` and `Changes: None (planning only)` for a plan. Use
`Awaiting user verification` after an implementation draft or correction. Use
`Changes: None (read-only)` for review. A completed review may use agent status
`Completed` even when its verdict is `Blocked`. Report only current-task
changes, not an already-dirty repository-wide diff. Never report an unrun or
blocked check as passed.

## Feature and enhancement verification stages

1. **Plan:** inspect scope, reuse, existing packages, and SDK support; present a
   concise plan and wait for explicit implementation approval.
2. **Implementation draft:** implement the smallest coherent version. Do not
   create or update automated tests, and do not run unit, widget, integration,
   golden, or full test suites. Formatting touched files plus targeted static
   analysis, lint, syntax, type, import, and reference checks remain allowed.
3. **User verification:** summarize the result, list exact changed files, give
   short device/emulator/manual steps, ask the user to check appearance,
   interaction, and behavior, then stop with `Awaiting user verification`.
4. **Corrections:** apply requested corrections and repeat stages 2-3. Feedback,
   correction requests, and implementation approval are not test approval.
5. **Test finalization:** only after the user clearly confirms the behavior or
   asks to add, update, run, or finalize tests, follow
   `docs/AGENT_TESTING_STRATEGY.md`: inventory nearby coverage, name realistic
   risks, state a test budget, prefer one primary test owner per behavior,
   consolidate equivalent cases, run narrow relevant tests first, and broaden
   only when the documented risk rules justify it. Invoke the final reviewer
   only after files and test results are stable.

An early automated test is allowed only when the user explicitly requests it,
or when it is genuinely required to prevent a critical security, clinical
safety, migration, or data-loss risk. For the risk exception, explain the need
and request approval before adding or running the test.

This staged rule primarily covers features and enhancements. A proven localized
bug may use its established narrow workflow, including a proportional
regression test, but must not trigger a broad suite without justification.

## Flutter working standards

- Keep implementation simple and understandable for a developer learning
  Flutter.
- Every handwritten Dart file created or substantially changed needs concise
  comments explaining its purpose, important Flutter concepts, and non-obvious
  decisions. Do not edit generated files.
- Keep business rules outside widgets and domain code independent of Flutter UI
  and database packages.
- Search existing code and Flutter/Dart SDK capabilities before adding a widget,
  service, abstraction, package, navigation/state system, or persistence system.
- Use SQLite for structured domain data, preferences for small settings, secure
  storage for secrets, and memory for temporary state unless an approved
  decision says otherwise.
- Maintain one documented owner/system per responsibility.
- Respect accessibility, semantics, touch targets, text scaling, reduced
  motion, Android/iOS differences, permissions, lifecycle, and profile-mode
  performance.

## Verification

Choose the narrowest checks that prove the current stage. After explicit test
finalization approval, full Flutter session checks, when required, run from
`goalify_app/`:

- `dart format --output=none --set-exit-if-changed .`
- `flutter analyze`
- `flutter test`
- Platform build/run checks required by the migration session

Before user verification, limit checks to the non-test checks allowed above.
Do not run application tests for documentation or agent-configuration-only
changes.
