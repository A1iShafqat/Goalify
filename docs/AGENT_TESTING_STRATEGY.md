# Agent Testing Strategy

This document is the shared testing policy for Goalify's Codex and Antigravity
implementation and reviewer roles. Optimize for confidence per test, not test
count or coverage percentage. Preserve meaningful existing coverage; consolidate
only when the same realistic risk is demonstrably protected more than once.

## Workflow gate

For features and enhancements, keep implementation and behavioral-test
finalization separate:

1. Inspect requirements, nearby implementation, packages, and existing tests.
2. Plan the implementation and obtain any required approval.
3. Implement the smallest coherent draft.
4. Run only formatting, lint, syntax, type, import, and targeted static-analysis
   checks.
5. Hand off with `Awaiting user verification` and
   `Tests not run - awaiting user verification.`
6. Apply user corrections and repeat the lightweight checks and handoff.
7. Add or update behavioral tests only after the user confirms the behavior or
   asks to proceed with tests.
8. Finalize tests efficiently and report exact results.

Unit, state/provider, widget, integration, golden, and full-suite tests are
behavioral tests. A request to add, update, run, or finalize tests is approval
for that requested testing work; do not ask again. Implementation approval,
feedback, or a correction request alone is not test approval.

A proven localized bug may receive a focused regression test when it is useful
to prove the fix. Do not broaden it into unrelated coverage. Critical security,
privacy, migration, or data-loss risk may justify earlier testing only after the
agent explains the risk and receives approval.

## Coverage inventory and budget

Before adding tests during finalization:

1. Read the changed behavior and its nearest existing tests.
2. List distinct, realistic failure modes.
3. Identify risks already covered at any layer.
4. Update, merge, or remove obsolete or duplicate tests before adding new ones.
5. State a reasonable test budget tied to the uncovered risks.

For a localized form, validation, default-value, mapping, or API-save change,
start with approximately 3-7 direct tests. This is not a hard cap. Exceed it
only for named, non-overlapping risks. A complete feature may need more when
domain calculations, persistence or request mapping, response parsing, state
orchestration, and UI wiring protect different failures.

## One primary owner per behavior

Use the lowest effective layer:

- **Pure unit/domain:** parsing, conversion, calculations, validation, scoring,
  grouping, dates, ranges, and deterministic mappings.
- **State/provider:** meaningful state transitions, save orchestration, and
  observable request construction not provable through pure functions.
- **Widget:** rendered labels and states, accessibility semantics, interaction,
  enabled state, and navigation triggers.
- **Repository/contract:** persisted or outgoing keys, enum encodings,
  representative response casing, migrations, and response-envelope behavior.
- **Integration/device:** native plugins, permissions, lifecycle, storage,
  notifications, platform behavior, or a real multi-component flow.

Do not independently test the same calculation at domain, state, and widget
layers unless each test protects a different realistic regression. When a bug
crossed layers, prefer one focused cross-layer proof plus lower-layer tests only
for distinct rules.

## Consolidation and risk priority

Use readable table-driven tests when setup and behavior are equivalent, such as
enum variants, boundary ranges, response casing, duration filters, empty or
sparse data, and success/failure envelopes. Do not create a separate test for
every field or variant when one table protects the same contract.

Prioritize tests protecting:

- Goalify scoring, recurrence, completion/undo, immutable results, and Routine
  snapshot ownership;
- precision, rounding, thresholds, stable IDs, dates, local time, time zones,
  week boundaries, and rollover;
- exact persistence/API keys, enum or string encodings, representative response
  casing, migrations, and restart behavior;
- loading, validation, empty, error, retry, and success states;
- permissions, notifications, lifecycle, accessibility, and one cross-layer
  regression where a failure crossed layers.

Avoid tests whose main purpose is to test a fake, mock, framework, or package;
protect an unimplemented stub; assert exact rebuild/notification counts; repeat
the same null handling across repositories; inspect private implementation;
construct a complete destination just to prove navigation; preserve obsolete
structure; add production seams solely for trivial tests; or split tiny
variations into separate files.

## Harness hygiene

Tests must use small configurable fakes, capture only meaningful outgoing data,
use placeholder navigation destinations, mock native channels when required,
initialize and clear global state, and use deterministic clocks and dates.
Never use real credentials, tokens, production payloads, or personal data.

A passing run is not clean if it contains swallowed exceptions, missing-plugin
errors, provider lookup failures, expected-error stack traces, leaked timers, or
other unexplained noise.

## Efficient execution and reporting

After test changes stabilize:

1. Format changed test files.
2. Iterate with the smallest affected test files.
3. Run static analysis once.
4. Run the complete suite once at finalization when shared models, routing,
   state/providers, repositories, migrations, or test infrastructure changed.
5. For an isolated test-only change, focused verification may be sufficient;
   explain why the full suite was skipped.

Do not repeatedly run the full suite after small edits. Run required device or
platform checks only where the changed behavior needs them.

For test-heavy work, report test-file count before and after, test count before
and after, approximate line-count change, focused-test result, and full-suite
result and duration when run. Runtime is diagnostic evidence, not a guaranteed
performance benchmark. Never report an unrun or blocked check as passed.

## Reviewer quality gate

The reviewer checks that every test protects a distinct risk, equivalent cases
are consolidated, assertions prove observable behavior, important domain and
wire/persistence contracts are covered, each behavior uses the correct layer,
obsolete duplicates were not retained, the harness runs cleanly, and the
implementation agent respected the user-verification gate.

During user verification, intentionally deferred tests are not a defect. Report
`Tests not run - awaiting user verification.` After test finalization, explain
findings with practical impact first, then name the exact file, behavior, or
contract.
