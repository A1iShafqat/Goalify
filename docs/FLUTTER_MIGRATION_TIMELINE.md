# Goalify Flutter Migration Timeline

**Recommended duration:** 3 calendar weeks  
**Suggested dates:** July 16 to August 5, 2026  
**Session length:** 2–3 hours  
**Core cadence:** 3 sessions per week  
**Planned reserve:** 1 additional session during Week 3  
**Estimated focused effort:** 20–30 hours

## Recommendation

Use the full three weeks. A two-week migration is possible only by working four or more sessions per week, reducing the validation scope, or accepting more schedule risk. That does not fit the stated side-project pace as well as the three-week plan.

This timeline migrates the **current MAUI prototype** and completes the **Flutter validation slice**. It does not deliver the complete Goalify MVP described in the PVRD.

## Expected result after three weeks

By the end of this timeline, Goalify should have:

- A working Flutter application with a simple, maintainable project structure.
- Android and iOS project configuration, with iOS build verification dependent on access to macOS and Xcode.
- App theme, motion tokens, navigation, linting, and an initial test structure.
- Pure Dart models for the first Goalify domain concepts.
- A versioned local SQLite database foundation.
- Activity list, create, and edit behavior comparable to the useful part of the MAUI prototype.
- A small dashboard slice with seeded Goal Plan/Routine data.
- Routine completion, undo, swipe interaction, progress feedback, and haptics.
- A reduced-motion and accessible alternative to gesture-only behavior.
- A local-notification proof of concept.
- Analyzer, unit, and targeted widget-test results.
- A written decision confirming whether Flutter is comfortable and safe enough for the remaining MVP.

The MAUI project remains available as a reference during the migration. It should not receive new product features.

## Explicitly outside this timeline

The following work should not be squeezed into these three weeks:

- Complete onboarding and user-profile design.
- The full recurrence and acceptance-criteria engine.
- Final Daily/Weekly/Monthly scoring behavior and all edge cases.
- Production-ready templates, to-dos, reminders, archive/renew flows, or analytics.
- Import/export and backup.
- Final branding, illustrations, advanced animations, and complete screen designs.
- Store signing, publishing, monetization, ads, or purchases.
- Exhaustive device coverage.
- Production-grade iOS validation when a Mac, Xcode, and iPhone are unavailable.

Those belong to the post-migration MVP roadmap.

## Working rhythm for a side project

Each session should have one main outcome. Do not use a session as an open-ended coding block.

Suggested 2–3 hour structure:

| Time | Activity |
|---:|---|
| 10–15 minutes | Review the previous session and choose the exact stopping point. |
| 25–40 minutes | Learn the Flutter concepts required for this session using a small Goalify example. |
| 60–100 minutes | Implement the single planned outcome. |
| 20–30 minutes | Format, analyze, test, and update comments/notes. |
| 5–10 minutes | Record the next action so restarting after a few days is easy. |

Rules for keeping the schedule realistic:

- Stop with the project building and analyzable whenever possible.
- Do not start a second major task because a session has a little time left.
- Move unfinished work to the next session instead of doubling the next day's hours.
- Include learning inside the 2–3 hour session; do not assume additional study time.
- Use the reserve session for genuine migration problems, not extra features.
- If a week is missed, shift the dates. Do not compress two sessions into one night.

### Required review checkpoint after every session

After the Flutter Architecture Expert finishes a session:

1. Use its **Review Completed Session** handoff or select the Flutter Session Reviewer.
2. Ask it to review the named session against this timeline and the architecture rules.
3. Resolve Critical findings before doing any other migration work.
4. Resolve Missing must-haves before starting a dependent next session.
5. Confirm or reject every unconfirmed dual-system overlap.
6. Track accepted Medium and Low findings without silently expanding the next session.

The reviewer is read-only. Implementation remains the responsibility of the Flutter Architecture Expert after the user approves the correction approach when approval is required.

## Week 1 — Flutter foundation and architecture

**Dates:** July 16–22  
**Effort:** 3 sessions, 6–9 hours  
**Goal:** Establish a clean Flutter foundation that the user understands and can modify.

### Session 1 — Confirm decisions and create the Flutter application

**Time:** 2–3 hours

Planned work:

- Confirm the new Flutter app location and how the MAUI prototype will be retained.
- Verify Flutter, Dart, Android SDK, emulator/device, and editor setup.
- Confirm whether macOS/Xcode access exists for iOS validation.
- Create the Flutter project with Android and iOS targets.
- Run the untouched app on Android before adding architecture or packages.
- Explain the Flutter project structure and compare it with the MAUI single-project structure.
- Add basic linting and confirm `flutter analyze` is clean.

Session outcome:

- The default Flutter application launches on an Android emulator or device.
- The user knows where entrypoint, widgets, Android configuration, iOS configuration, and tests live.
- Environment limitations are documented before feature work begins.

Do not spend this session choosing every future package or creating all folders.

### Session 2 — Establish the smallest useful application structure

**Time:** 2–3 hours

Planned work:

- Choose the first state-management and dependency approach after comparing SDK and package options.
- Create only the initial presentation, application, domain, and data boundaries needed by the migration.
- Add app-level theme, spacing, typography, and basic motion tokens.
- Create the initial navigation shell for Home, Routines, Activities, and Profile placeholders.
- Add beginner-friendly comments explaining widgets, `build()`, immutable configuration, and navigation with MAUI comparisons.
- Add one small navigation/widget test.

Session outcome:

- The app opens into the Goalify navigation structure.
- Theme and navigation are centralized.
- No business logic or database code lives inside screens.
- The structure is understandable without opening many empty abstractions.

### Session 3 — Model the first domain slice in pure Dart

**Time:** 2–3 hours

Planned work:

- Define the minimum models needed for migration: `ActivityDefinition`, `GoalPlan`, `RoutineGoal`, and `CompletionEvent`.
- Keep the models independent of Flutter widgets and SQLite rows.
- Define identifiers and the relationships missing from the MAUI prototype.
- Add mapping boundaries only where persistence requires them.
- Write focused unit tests for model creation and basic invariants.
- Explain immutable Dart models and compare them with the current C# models.

Session outcome:

- The initial domain compiles without Flutter or database imports.
- Relationships are explicit through identifiers.
- Unit tests demonstrate the intended behavior.

### Week 1 exit gate

Continue only when:

- The Flutter app launches reliably on Android.
- `flutter analyze` passes.
- Navigation and theme foundations work.
- The user can explain `Widget`, `build()`, `StatelessWidget`/state ownership, `Future`, and the chosen state approach at a basic level.
- Initial domain tests pass.

If the environment is still unstable, use the first session of Week 2 to fix it. Do not build features on an unreliable foundation.

## Week 2 — Migrate useful MAUI prototype behavior

**Dates:** July 23–29  
**Effort:** 3 sessions, 6–9 hours  
**Goal:** Reach functional parity with the useful Activity portion of the existing MAUI prototype.

### Session 4 — Add local database and repository foundation

**Time:** 2–3 hours

Planned work:

- Evaluate the SQLite package and migration approach before adding it.
- Add the approved database dependency and platform configuration.
- Create database version 1 and an Activity table.
- Create an Activity repository interface and SQLite implementation.
- Add create, update, and list operations.
- Add repository/database tests where the selected library makes them practical.
- Explain repository separation and compare it with the MAUI `SQLiteService`.

Session outcome:

- Activities can be saved and loaded through the repository.
- Widgets do not know about SQL or database package types.
- The initial schema has an explicit version and migration entrypoint.

Keep Goal Plans, routines, reminders, and completion storage out of this session unless time remains after verification. They are not required for Activity parity.

### Session 5 — Build Activity list, create, and edit screens

**Time:** 2–3 hours

Planned work:

- Create the Activity list screen.
- Create a single Activity form that supports both add and edit behavior.
- Add simple validation and save/error states.
- Connect UI state to the application/repository flow.
- Use a safe icon identifier rather than storing rendered icon image bytes when possible.
- Add useful comments for state updates, asynchronous saving, form lifecycle, and navigation.
- Add targeted widget tests for empty, populated, validation, and saving states.

Session outcome:

- The user can create and edit an Activity.
- The Activity list updates correctly.
- The flow remains understandable and does not duplicate add/edit logic.

### Session 6 — Complete prototype parity and persistence checks

**Time:** 2–3 hours

Planned work:

- Add the Activity swipe action with a visible non-gesture alternative.
- Verify data after app restart.
- Handle empty, loading, validation, and persistence-error states.
- Review the migrated flow against the MAUI Activity behavior.
- Remove temporary sample code and confusing placeholder behavior.
- Run formatting, analysis, unit tests, and widget tests.
- Write a short parity report listing behavior intentionally changed or deferred.

Session outcome:

- The useful Activity portion of the MAUI prototype exists in Flutter.
- Data survives restart.
- The flow has basic accessibility semantics and test coverage.
- The project returns to a clean build/analyzer state.

### Week 2 exit gate

Continue only when:

- Activity create, list, edit, validation, and persistence work.
- No Flutter widget executes database operations directly.
- App restart does not lose saved Activities.
- The user can follow the path from screen action to state/use case to repository.
- Analyzer and relevant tests pass.

## Week 3 — Validate Goalify's interaction direction

**Dates:** July 30–August 5  
**Effort:** 3 core sessions plus 1 reserve session, 8–12 hours  
**Goal:** Prove the Flutter-specific reasons for migrating: responsive completion, gesture, motion, persistence, and platform behavior.

### Session 7 — Build the small daily-dashboard slice

**Time:** 2–3 hours

Planned work:

- Add only the database tables/repositories needed for a seeded Goal Plan, two Routine Goals, and Completion Events.
- Populate a simple dashboard from local data.
- Implement complete and undo behavior.
- Use optimistic UI feedback while persistence completes safely.
- Add unit tests for complete/undo behavior.
- Explain reactive state flow and compare it with `ObservableProperty`/`INotifyPropertyChanged`.

Session outcome:

- The dashboard loads two local routines.
- Complete and undo work after restart.
- Completion data is stored as events rather than a single fragile UI flag.

This is not the full recurrence or scoring engine. Use fixed seeded routines and a simple progress calculation for the validation slice.

### Session 8 — Add meaningful motion, gestures, and accessibility

**Time:** 2–3 hours

Planned work:

- Add a responsive check-off interaction.
- Add swipe behavior with a button/menu alternative.
- Animate progress and show a brief encouraging completion response.
- Add haptic feedback where supported.
- Implement reduced-motion behavior.
- Add semantic labels and verify large-text behavior for the slice.
- Add or update widget tests for interaction states.
- Profile the interaction in Flutter profile mode on a physical Android device when available.

Session outcome:

- The core interaction demonstrates why Flutter was chosen.
- All actions remain usable without gestures or animation.
- Motion communicates state and success rather than adding decoration only.
- There is recorded profile-mode evidence rather than a debug-mode impression.

### Session 9 — Local-notification proof of concept

**Time:** 2–3 hours

Planned work:

- Evaluate and add the approved local-notification package.
- Implement permission handling and one scheduled routine reminder.
- Use a stable notification identifier for update/cancel behavior.
- Test schedule, receive, update, and cancel on Android.
- Configure and test iOS only when macOS/Xcode and a suitable simulator/device are available.
- Document platform limitations and remaining production-hardening work.

Session outcome:

- One reminder can be scheduled and canceled on the locally testable platform.
- Notification code is behind a small application-facing service.
- iOS status is explicitly recorded as passed, failed, or blocked by environment.

Do not expand this proof into the complete recurrence/reminder engine.

### Reserve Session 10 — Stabilization and migration decision

**Time:** 2–3 hours

This is planned capacity, not bonus feature time.

Use it for the highest-priority unfinished item:

1. Environment or native-build problem.
2. SQLite migration or persistence defect.
3. State/lifecycle defect.
4. Notification platform issue.
5. Analyzer/test failure.
6. Performance or accessibility failure.

If no blocking work remains:

- Run the complete formatter/analyzer/test set.
- Run an Android physical-device smoke test.
- Run an iOS smoke test if the environment exists.
- Review learning comments for accuracy.
- Update the architecture and migration documents with actual decisions.
- Record migrated, deferred, removed, and newly discovered work.
- Decide whether Flutter becomes the permanent Goalify codebase.

### Week 3 exit gate

The migration slice is complete when:

- The Flutter application launches and retains local data.
- Activity parity works.
- Dashboard complete/undo works after restart.
- Gesture, non-gesture, motion, and reduced-motion paths work.
- At least Android notification scheduling and cancellation are demonstrated.
- Physical-device profile testing has been performed on Android when a device is available.
- iOS has a verified result or a clearly documented environment blocker.
- Analyzer and targeted tests pass.
- The user can safely explain and modify the main state and repository flow.

## If only two weeks are available

A two-week version should use 4 sessions per week for 16–24 total hours and reduce scope. Do not try to fit all ten sessions into two weeks.

Recommended cuts:

- Keep Sessions 1–6 to establish Flutter and migrate Activity parity.
- Use one session for the dashboard completion/undo slice.
- Use one session for motion and Android profiling.
- Move notifications, iOS validation, and extended accessibility checks to Week 3 or the later MVP roadmap.

The two-week outcome is therefore **prototype migration plus partial Flutter validation**, not a completed cross-platform migration decision.

## Schedule risks and responses

| Risk | Likely effect | Planned response |
|---|---|---|
| Flutter/Dart learning takes longer than expected | One session may produce less code | Protect learning time and reduce scope; do not remove tests or comments. |
| Package or Gradle configuration problem | Database or notification work slips | Use Reserve Session 10 and stop adding extra features. |
| No Mac/Xcode access | iOS cannot be built or physically tested | Complete Android locally and schedule a separate Mac validation session. |
| State-management approach feels confusing | Future code becomes hard to maintain | Stop after a small proof, compare alternatives, and change early. |
| Database design expands toward the full MVP | Activity migration stalls | Keep Week 2 schema limited; add only dashboard tables in Session 7. |
| Animation experimentation consumes the schedule | Core behavior remains incomplete | Build one completion sequence only; defer advanced effects. |
| Several days pass between sessions | Restarting consumes time | End every session with a clean state and a written next action. |

## Definition of migration success

Migration success is not measured by deleting the MAUI folder or reproducing every prototype file. It is successful when:

- Useful existing behavior has an understandable Flutter replacement.
- The new architecture supports Goalify's offline domain without copying MAUI coupling.
- The interaction slice shows that Flutter meets the desired motion and gesture direction.
- The user can continue development without depending on unexplained generated code.
- Remaining work is explicitly part of the MVP roadmap rather than hidden inside “migration.”

After this timeline, retain the MAUI project read-only until the Flutter Activity and dashboard flows have remained stable through the next MVP milestone. Archive or remove it in a separate, explicit decision.
