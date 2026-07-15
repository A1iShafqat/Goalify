# Goalify Framework Decision and Technical Direction

**Status:** Proposed decision  
**Date:** July 15, 2026  
**Scope:** Android and iOS mobile application  
**Inputs:** Goalify Product Vision & Requirements Document (PVRD), current repository, and current official MAUI and Flutter documentation

## Executive decision

**Migrate Goalify to Flutter now, while the product is still at prototype stage.**

Do not begin by translating every MAUI page. Start with a time-boxed Flutter vertical slice that proves the product's highest-risk experience: the daily dashboard, one-tap completion, swipe interaction, completion feedback, local persistence, and a scheduled notification. If that slice passes the acceptance gates in this document, Flutter becomes the production codebase and the remaining MAUI prototype is retired.

This is not a conclusion that MAUI cannot produce an attractive or smooth application. MAUI supports gestures, basic and custom animations, graphics, and native platform customization. The deciding factor is the combination of:

- Goalify's desired product identity depends on frequent, polished, motion-rich interactions.
- Flutter provides a more unified rendering and animation model for this kind of interface.
- The current MAUI code contains very little completed product behavior to protect.
- The cost of changing frameworks will increase sharply after the scoring engine, completion history, dashboard, and design system are built.
- The current app targets .NET MAUI 9, which is already out of support as of May 12, 2026. Staying would first require upgrading to MAUI 10 and resolving the current build and package issues.

The recommendation would reverse to **stay with MAUI 10** if the real priority is shipping a conventional native-looking MVP as quickly as possible and motion is decorative rather than part of the product experience.

## What the product requires

The PVRD describes an offline, privacy-first routine tracker whose main interaction should feel instantaneous and encouraging. Its MVP requires:

- A local user profile.
- Goal Plans containing reusable Routine Goals and Activity definitions.
- Flexible repetition and acceptance criteria rather than daily streaks.
- Daily, weekly, and monthly scoring buckets.
- An Essential flag that gives a routine two shares within its bucket.
- A daily dashboard combining routines, one-off to-dos, and reminders.
- Local notifications.
- Completion feedback using text, graphics, and icons.
- Built-in templates.
- A complete local database with no cloud dependency.
- Later import/export, analytics, collaboration, rich notes, AI features, ads, and a one-time premium purchase.

The framework-independent technical center of Goalify is therefore the scheduling and scoring domain. The visible product differentiator is the speed and quality of the daily completion experience.

## Current repository assessment

### What exists

The repository has a reasonable prototype skeleton:

- A MAUI Shell with Home, Routine, Activities, and Profile tabs.
- Basic Activity create/edit/list behavior backed by SQLite.
- A swipe action on Activity rows.
- Early models for Goal Plan, Routine Goal, repetition, Activity, and notification requests.
- Android and iOS notification implementation experiments.
- CommunityToolkit.Mvvm, CommunityToolkit.Maui, SQLite, SkiaSharp, and icon packages.

There are 61 C#, XAML, and project files, but much of that is template code, styles, generated resources, test/prototype code, and platform scaffolding. The Home screen currently opens a test page, and Routine creation is still a placeholder.

### What is not implemented

The following PVRD capabilities are not yet product-ready:

- Onboarding and local profile.
- Goal Plan creation and lifecycle.
- Routine scheduling and acceptance criteria.
- Completion-event history.
- The scoring engine and score snapshots.
- Daily dashboard composition.
- Standalone to-dos and reminders.
- Templates.
- End-of-plan archive, renew, or adjust flows.
- Import/export.
- Analytics.
- A design system, motion system, reduced-motion behavior, and accessibility semantics.
- Automated unit, widget/UI, integration, or migration tests.

### Current technical risks

The current solution does not build. The local `dotnet build --no-restore` check produced one error and 26 package warnings:

- `RoutineGoalModel` refers to `RoutineRepitationModel`, while the defined type is `RoutineRepetationModel`.
- The explicitly referenced AndroidX lifecycle package version conflicts with transitive package constraints.
- The app targets MAUI 9.0.120; MAUI 9 is out of support.
- Dependency injection registers the shared `LocalNotificationService`, whose methods throw `NotImplementedException`, rather than selecting the platform implementations.
- The generic SQLite service creates isolated tables but does not model relationships, schema migrations, transactions, or queries needed by the PVRD.
- `GoalPlanModel.ActivityGoals` is an in-memory list, not a persisted relational association.
- A Routine Goal has no persisted Goal Plan foreign key.
- There is no completion-event entity, so acceptance criteria and historical scores cannot be calculated reliably.
- Navigation and MAUI UI types leak into the view-model and common layers, reducing portability and testability.

These are normal prototype-stage issues. They are evidence that the project has not accumulated a large body of production-ready MAUI work.

## MAUI versus Flutter for Goalify

The scores below are a Goalify-specific planning aid, not a universal framework benchmark. Each option is scored from 1 to 5 and weighted according to the stated product goal that smooth gesture and animation work is important.

| Criterion | Weight | MAUI | Flutter | Reasoning |
|---|---:|---:|---:|---|
| Motion and gesture authoring | 30% | 3 | 5 | MAUI has capable APIs, but Flutter treats animation, painting, layout, and gestures as parts of one compositional widget system. |
| Cross-platform visual consistency | 15% | 3 | 5 | MAUI controls map to native platform controls; Flutter lays out and paints its own UI. Flutter therefore gives tighter control over matching motion and visuals across devices. |
| Developer productivity in the first month | 15% | 5 | 2 | Existing C# and MAUI experience strongly favors MAUI; Flutter requires learning Dart, its widget model, tooling, and ecosystem. |
| Long-term UI experimentation | 15% | 3 | 5 | Flutter has a broad built-in catalog for implicit, explicit, list, transition, and Hero animations. |
| Preservation of current implementation | 10% | 5 | 1 | C# and XAML cannot be reused directly. However, little completed product behavior currently exists. |
| Offline data and platform services | 10% | 5 | 4 | Both can meet the requirement. MAUI has a small advantage from existing .NET knowledge and direct native-control integration. |
| Framework/toolchain maintenance risk | 5% | 3 | 4 | Both require upgrades. MAUI's current support policy requires keeping pace with annual .NET/MAUI releases and platform SDK changes. |
| **Weighted result** | **100%** | **74/100** | **80/100** | Flutter wins only because Goalify explicitly assigns high importance to custom motion and consistent polish. |

### What MAUI can do

MAUI is not blocked from delivering the PVRD. It provides:

- Tap, pan, pinch, swipe, pointer, drag, and drop gesture recognizers.
- Basic transform animations such as scale, fade, rotation, and translation.
- Custom and synchronized child animations through the `Animation` class.
- Community Toolkit behaviors and reusable animation classes.
- Native control handlers and platform-specific customization.
- SkiaSharp or `GraphicsView` for custom drawing.

For a conventional tracker UI with restrained micro-interactions, MAUI 10 is a valid choice and likely the fastest choice for the current developer.

The concern is not raw possibility. The concern is the amount of custom code, platform checking, handler work, and testing that may be required to maintain a highly choreographed interface across both Android and iOS. MAUI's native-control mapping is beneficial for native behavior, but it makes exact cross-platform visual parity less automatic.

### Why Flutter better matches the stated design ambition

Flutter's framework, engine, and widget model are designed around compositing and painting the complete scene. Gestures, layout, painting, and animations participate in the same reactive UI tree. Its SDK includes implicit animation widgets, explicit animation primitives, animated lists, transitions, custom painting, and shared-element Hero transitions.

This does not guarantee a smooth app. Poor widget rebuilds, heavy effects, synchronous work, and unmeasured rendering can still cause jank. It does make the desired interaction model easier to express, profile, and keep visually consistent.

## Migration cost and learning risk

The user's estimate of one to two weeks is plausible for recreating the **current visible prototype**, but not for simultaneously becoming production-proficient in Flutter and delivering the PVRD MVP.

Treat these as separate costs:

1. **Prototype migration:** recreate navigation, Activity CRUD, SQLite storage, and notification proof of concept.
2. **Flutter learning:** Dart, widget composition, state and lifecycle, asynchronous code, navigation, testing, platform configuration, performance profiling, and release tooling.
3. **Actual product development:** the unimplemented Goalify domain, design system, screens, edge cases, migrations, and tests.

The first cost is small. The second creates an early productivity dip. The third dominates the schedule regardless of framework.

Do not port the current MVVM structure line by line. Preserve the concepts and requirements, not accidental prototype architecture. The current assets and user-facing copy can be reused; C# UI, view models, Shell navigation, and platform service code will be rewritten.

## Required Flutter validation slice

Before migrating the entire repository, build one production-shaped vertical slice in Flutter. Time-box it to approximately five focused working days, with a hard stop for evaluation.

### Slice scope

- A local database with an Activity, one Goal Plan, two Routine Goals, and completion events.
- A dashboard that loads today's routines from the database.
- Instant optimistic completion and undo.
- A swipe action on a routine card.
- An animated progress indicator and a short, encouraging completion celebration.
- Haptic feedback where supported.
- A reduced-motion path that preserves all meaning without movement.
- App restart with persisted state.
- One scheduled local notification on Android and iOS.
- Profile-mode testing on at least one representative physical Android device and one physical iPhone before final commitment.

### Pass gates

- The developer can explain and safely modify the state flow without copying unfamiliar code blindly.
- Completion remains responsive while persistence runs asynchronously.
- The core transition and gesture sequence has no sustained frames over the approximately 16 ms budget on the chosen 60 Hz test devices in profile mode.
- The same interaction behaves correctly with screen-reader semantics and reduced motion.
- Database state remains correct after complete, undo, app termination, date rollover, and device time-zone change tests.
- Notification permission, scheduling, cancelation, and rescheduling work on both platforms.
- No critical feature depends on an abandoned or unmaintained package.

### Fail response

If the slice cannot pass because Flutter learning cost is preventing safe implementation—not because of a solvable prototype bug—stop the migration and upgrade the MAUI app to MAUI 10. The domain and data design proposed below remains valid in either framework.

## Proposed target architecture

Keep the architecture simple enough for a solo developer while protecting the scoring rules from UI and storage changes.

```text
Presentation
  Screens, reusable widgets, motion, accessibility, view state
        |
Application
  Use cases: complete routine, undo completion, build dashboard,
  calculate score, archive/renew plan, schedule reminder
        |
Domain
  Entities, value objects, recurrence rules, acceptance engine,
  scoring policies; no Flutter or database imports
        |
Data and platform adapters
  SQLite repositories, migrations, local notifications,
  import/export, preferences, haptics, purchases/ads later
```

Rules:

- Domain scoring and recurrence logic must be pure Dart with deterministic unit tests.
- Screens must not issue SQL or schedule native notifications directly.
- Store completion events as facts; derive daily status and scores from those facts.
- Make all date calculations explicit about local date, time zone, and week start.
- Put schema migrations under version control from the first Flutter database version.
- Keep animation tokens—durations, easing curves, distances, haptic types—in a central motion theme.
- Respect the operating system's reduced-motion and accessibility preferences.
- Keep ads, analytics, cloud sync, and AI outside the core local habit-data path.

## Proposed domain and data model

The PVRD needs more than the current five models.

| Entity/value object | Purpose |
|---|---|
| `LocalProfile` | Name, optional age, avatar reference, onboarding/privacy acknowledgement. |
| `GoalPlan` | Name, lifecycle state, start/end dates, archive/renew metadata. |
| `ActivityDefinition` | Reusable name, description, icon identifier, optional color. |
| `RoutineGoal` | Links a Goal Plan to an Activity and holds Essential status and category. |
| `RepetitionRule` | Daily, weekly, monthly, selected weekdays, interval, and future extensibility. |
| `AcceptanceCriterion` | Required completions within a defined cycle. |
| `CompletionEvent` | Immutable completion/undo facts with routine ID, local date, and timestamp. |
| `Reminder` | Target entity, local scheduled time, recurrence, enabled state, platform schedule ID. |
| `TodoItem` | Standalone dashboard task with optional due date/time and completion state. |
| `Template` | Built-in starter Goal Plan and Routine Goal definitions. |
| `ScoreSnapshot` | Optional persisted end-of-cycle/end-of-plan result for auditability. |
| `AppSetting` | Week start, notification preferences, reduced motion override if offered. |

Use relational join keys rather than object lists inside persisted records. In particular, `RoutineGoal` must contain a `GoalPlanId` and `ActivityDefinitionId`, while `CompletionEvent` must contain a `RoutineGoalId`.

## Scoring engine rules that need specification

The PVRD gives a clear worked example but leaves important edge cases undecided. These must be resolved before implementing the scoring engine:

1. Are the Daily/Weekly/Monthly weights always 60/30/10, are they template-defined, or can users edit them?
2. If a Goal Plan has no tasks in one category, is that category's weight redistributed or removed from the denominator?
3. Does completion above the acceptance target stop at 100%, or can it produce bonus progress?
4. How are partial completions represented, or are completion events always binary?
5. What is the start of the week, and can the user change it?
6. How are routines handled when a Goal Plan starts or ends in the middle of a cycle?
7. What happens when a user changes a routine's criteria or Essential flag during an active cycle?
8. Do late/backdated completions change already displayed or finalized scores?
9. How are daylight-saving and time-zone changes handled for due dates and reminders?
10. Is the final score rounded, truncated, or displayed with decimals before mapping to 1-100?

Until these are answered, keep scoring policies versioned so an algorithm change does not silently rewrite historical results.

## Delivery sequence after the framework decision

The side-project schedule for the migration and validation slice is defined in [Goalify Flutter Migration Timeline](FLUTTER_MIGRATION_TIMELINE.md).

### Phase 0 — Decision slice

Build and evaluate the Flutter vertical slice. Do not add new MAUI product features during this time.

### Phase 1 — Foundation

- Establish the Flutter app, linting, test structure, themes, motion tokens, and navigation.
- Implement the versioned database and repositories.
- Implement and test recurrence, acceptance, and scoring policies.
- Implement notification and clock abstractions.

### Phase 2 — Core MVP flows

- Onboarding and local profile.
- Activity definitions and icon selection.
- Goal Plan and Routine Goal creation.
- Daily dashboard, completion, undo, and reminders.
- Plan progress and final score.
- Archive, renew, and adjust flows.

### Phase 3 — Product polish

- Empty, loading, error, permission-denied, and date-rollover states.
- Completion motion, haptics, dashboard transitions, and encouraging graphics.
- Accessibility, reduced motion, large text, color contrast, and screen-reader testing.
- Physical-device performance profiling and battery checks.

### Phase 4 — Release hardening

- Import/export from the PVRD Phase 1.5 if required for launch.
- Database migration and backup/restore tests.
- Notification reliability tests.
- Privacy messaging and data-loss disclosure.
- Store assets, crash reporting policy, release signing, and staged rollout.

## If MAUI is retained instead

If the validation slice fails or schedule pressure outweighs motion ambition, staying with MAUI is still defensible. The minimum reset would be:

1. Upgrade from MAUI 9 to the latest supported MAUI 10 servicing release.
2. Remove the conflicting explicit AndroidX version and align package versions.
3. Fix the repetition type spelling mismatch and get both Android and iOS targets building.
4. Replace the shared notification stub with compile-time platform registrations.
5. Redesign the domain and SQLite schema before adding more UI.
6. Separate navigation/UI types from domain and application logic.
7. Create a MAUI motion proof of concept for the same dashboard slice and profile it on physical devices.
8. Commit to selective custom drawing/Skia only where standard native controls cannot meet the design.

Do not remain on the current MAUI 9 prototype unchanged.

## Decision summary

Goalify can be built in either framework. Flutter is recommended because the desired interaction quality is a first-class product requirement and the cost of changing is currently low. The cost is not the one-to-two-week code rewrite alone; it is the temporary loss of productivity while learning Flutter. A five-day vertical slice turns that uncertainty into evidence before the full MVP is committed.

The practical instruction is therefore:

> Pause MAUI feature work, validate the hardest Goalify interaction in Flutter, and migrate fully if the explicit quality and maintainability gates pass.

## Official references

- [.NET MAUI support policy](https://dotnet.microsoft.com/en-us/platform/support/policy/maui)
- [.NET MAUI controls and native mapping](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/?view=net-maui-10.0)
- [.NET MAUI handlers](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/handlers/?view=net-maui-10.0)
- [.NET MAUI custom animations](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/animation/custom?view=net-maui-10.0)
- [.NET MAUI Community Toolkit](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/)
- [Flutter architectural overview](https://docs.flutter.dev/resources/architectural-overview)
- [Flutter animation API overview](https://docs.flutter.dev/ui/animations/overview)
- [Flutter animation and motion widgets](https://docs.flutter.dev/ui/widgets/animation)
- [Flutter gesture system](https://docs.flutter.dev/ui/interactivity/gestures)
- [Flutter SQLite persistence](https://docs.flutter.dev/cookbook/persistence/sqlite)
- [Flutter performance profiling](https://docs.flutter.dev/perf/ui-performance)
