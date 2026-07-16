# Goalify Codex Guidance

## Repository scope

- The production Flutter app is in `goalify_app/`.
- The existing MAUI solution in `Goalify/` is a read-only migration reference unless the user explicitly requests a MAUI change.
- Product and migration decisions live in `docs/`.
- Read `docs/FRAMEWORK_DECISION_AND_TECHNICAL_DIRECTION.md` and `docs/FLUTTER_MIGRATION_TIMELINE.md` before foundational Flutter work.

## Project custom agents

Codex project agents are defined in `.codex/agents/`:

- `flutter_architecture_expert`: plan-first Flutter architecture, implementation, maintenance, and teaching.
- `flutter_session_reviewer`: independent read-only review with Critical, Missing must-have, Medium, Low, and dual-system findings.

### Routing

- For a new Flutter feature, enhancement, migration session, architectural change, or substantial explanation, delegate the bounded work to `flutter_architecture_expert`.
- The architecture agent must inspect requirements, perform the reuse/package check, share a plan, and wait for explicit user approval before implementing features or enhancements.
- A truly simple localized bug may be fixed directly under the architecture agent's narrow bug-fix rules.
- After each migration/development session, or whenever the user asks for a review, delegate a separate review to `flutter_session_reviewer` after implementation stops.
- Do not run implementation and review concurrently against changing files. The reviewer evaluates a stable session result.
- Critical findings block further work. Missing must-haves must be resolved before dependent work. Any overlapping dual-system design requires user confirmation.

## Flutter working standards

- Keep implementation simple and understandable for a developer learning Flutter.
- Every handwritten Dart file created or substantially changed must contain concise comments explaining its purpose, important Flutter concepts, and non-obvious decisions. Do not edit generated files.
- Keep business rules outside widgets and keep domain code independent of Flutter UI and database packages.
- Search for existing solutions before adding widgets, services, abstractions, packages, navigation systems, state systems, or persistence systems.
- Treat SQLite as structured domain storage, preferences as small settings storage, secure storage as secret storage, and in-memory state as temporary UI/application state unless an approved decision says otherwise.
- Maintain one documented source of truth for each responsibility.
- Respect accessibility, semantic labels, touch targets, text scaling, reduced motion, Android/iOS behavior, permissions, lifecycle, and profile-mode performance.

## Verification

Run checks from `goalify_app/`:

- `dart format --output=none --set-exit-if-changed .`
- `flutter analyze`
- `flutter test`
- Platform build/run checks required by the current migration session.

Do not report environment-blocked checks as passing. Keep required guidance in this file or checked-in documentation rather than relying on task memory.

