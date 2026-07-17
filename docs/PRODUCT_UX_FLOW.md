# Goalify Product UX Flow

**Status:** Approved product and design baseline  
**Date:** July 16, 2026  
**Scope:** Mobile MVP design for Android and iOS  
**Related sources:** Product Vision & Requirements Document (PVRD), `FRAMEWORK_DECISION_AND_TECHNICAL_DIRECTION.md`, `FLUTTER_MIGRATION_TIMELINE.md`, and `.stitch/DESIGN.md`

## Purpose

This document is the durable product-flow source of truth for Goalify. It translates the PVRD into user-facing language, navigation, screen flows, interaction rules, lifecycle states, and MVP boundaries. Technical names may differ internally, but the product UI should use only the concepts **Activity**, **Routine**, and **Goal**.

Goalify is an offline-first, privacy-first routine tracker that rewards consistency rather than perfect streaks. The daily experience should be fast, encouraging, understandable, and useful without network access.

## Approved product model

### Activity

An Activity is a reusable item such as Walk, Read, Stretch, or Drink Water.

An Activity definition stores:

- Name.
- Description.
- Icon from the built-in icon library.
- Visible default configuration that can help the user understand and reuse the Activity.

The default configuration is only a starting suggestion. When an Activity is added to a Routine, its recurrence, acceptance target, Essential status, and reminder are copied into that Routine and may be changed without changing the reusable Activity.

### Routine

A Routine is a reusable definition containing one or more configured Activities. It stores the intended structure and defaults for future use.

Starting a Routine creates a separate dated run with:

- A required start date.
- A required end date.
- A snapshot of the selected Activities and their configuration.
- A Goal target.
- Independent completion history and Results.

Restarting a Routine creates another run with new dates. It must not overwrite a previous run, its completions, score, calendar, or Results. Editing a saved Routine affects future runs only unless the user explicitly edits an active run through an approved flow.

The UI may offer **Save as Routine** when the user wants to preserve a modified configuration as another reusable definition. Routine sharing is future scope.

### Goal

A Goal is the minimum score the user wants to achieve for a Routine run. It is not a parent container and is not a separately created plan.

The Goal should support lightweight gamification:

- Show progress toward the target without using fragile daily streaks.
- Encourage one meaningful daily visit without guilt or punishment.
- Celebrate reaching the target.
- Use supportive language when the target is missed.
- Keep the Goal visible in Routine details and Results without crowding every Activity card.

### Results

Results are produced when a Routine run reaches its end date. Results preserve the final score, score breakdown, calendar status, Goal outcome, and motivation message. A past Result remains unchanged when the saved Routine is edited or restarted.

## Release boundaries

### MVP

- First-run onboarding and local profile.
- Today dashboard.
- Reusable Activities and visible default configuration.
- Saved Routines and separate dated Routine runs.
- Active and upcoming runs.
- Routine History and Results.
- Goal target score.
- PVRD scoring presentation.
- Standalone To-Dos.
- Standalone Reminders.
- Local notifications.
- Tool enable/disable visibility.
- Light, dark, accessibility, and reduced-motion states.

### V1.1

- Local import and export.
- Backup compatibility and restore-result flows.

### Future

- Routine sharing.
- Gallery images for Activity icons.
- Expanded analytics and insights.
- Social or collaborative routines.
- Advanced notes, AI tools, advertisements, and premium features.

Future capabilities must not appear as inactive or misleading controls in MVP designs.

## Primary navigation

Goalify uses three bottom destinations:

1. **Today** - daily work, progress, and finished-run Results cards.
2. **Routines** - Current, Saved, and History.
3. **More** - profile, tool management, settings, notifications, accessibility, scoring explanation, privacy, and about.

### Tool drawer

The drawer is a shortcut surface for enabled tools, not another primary navigation system.

The drawer contains:

- User avatar.
- Time-appropriate welcome and first name.
- A compact, optional summary such as today's completed count.
- Links only for enabled tools, initially To-Dos and Reminders.
- A **Manage tools** link that opens More > Tools.

The drawer does not duplicate Today, Routines, History, More, Profile, or Settings. Disabling a tool removes its drawer shortcut but never deletes, archives, or changes its stored data.

### App bar rule

- Root destination: drawer button, title, optional contextual action.
- Child screen: Back, title, optional contextual action.
- Do not show Back and the drawer button at the same time.
- Put long subtitles and explanatory copy in the page body so large text remains usable.

## First-run flow

1. **Welcome**
   - Explain consistency over perfection.
   - Explain that Goalify combines routines, To-Dos, and Reminders.
2. **Local privacy**
   - Data stays on this device.
   - V1.0 has no cloud recovery.
   - Losing or resetting the device may lose data.
   - Require acknowledgement before continuing.
3. **Create profile**
   - Avatar.
   - Name.
   - Date of birth.
   - Optional weight and height with clear units.
   - Weight and height do not affect MVP scoring; they are retained for future motivation and analytics.
4. **Get started**
   - Create a blank Routine.
   - Start from a built-in template.
   - Continue to Today and create later.

Notification permission should be requested in context when the user enables the first reminder, not automatically during onboarding.

## Today dashboard

### Information order

1. Date, greeting, and compact daily progress.
2. Active Routine sections, with Activities grouped under their Routine.
3. To-Dos, when enabled.
4. Standalone Reminders, when enabled.
5. Completed items, sorted below incomplete work.
6. Results cards for recently ended Routine runs that the user has not yet reviewed.

Do not show empty placeholders for disabled or future tools.

### Activity card

An Activity card should show only information needed for today's decision:

- Icon and Activity name.
- Routine name.
- Today-specific schedule or progress text.
- Reminder state when relevant.
- Visible completion control.
- Overflow menu exposing the same actions as gestures.

Detailed scoring configuration belongs in Routine detail or configuration screens, not on every dashboard card.

### Completion behavior

- Completion is immediate and optimistic.
- The item remains visible and moves below incomplete items.
- Use a bright motivational state, check icon, and explicit **Completed** label.
- Do not communicate completion through color alone.
- Offer Undo.
- If persistence fails, restore the correct state and explain the failure.
- An all-done moment may use a brief celebration, haptic feedback, and supportive copy.
- Reduced-motion mode preserves the same meaning without movement.

### Accepted swipe behavior

Gestures use logical start/end directions so they mirror for right-to-left languages. For an English left-to-right layout:

| Item | Left-to-right | Right-to-left |
|---|---|---|
| Routine Activity | Complete | Mute today; hide when no reminder exists |
| To-Do | Complete | Edit or reschedule |
| Standalone Reminder | Done | Delay |
| Completed item | Undo | Retain the relevant context action |

Delay opens understandable presets such as 10 minutes, 1 hour, Tomorrow morning, and Custom. It changes only the next occurrence; it does not silently modify the permanent schedule.

Mute today cancels only the remaining notification for that Activity occurrence. It does not skip the Activity, change scoring, or change future reminders.

Every gesture must have a visible completion control and menu alternative.

## Routines

The Routines destination has three top-level views:

### Current

- **Active:** runs whose dates include today.
- **Upcoming:** scheduled runs whose start date is in the future.
- Each card shows Routine name, dates, Goal target, progress, and the next relevant action.

### Saved

- Reusable Routine definitions.
- Actions: Start, Edit, Save as Routine, and Delete with confirmation.
- A future release may add Share.
- Starting requires new start and end dates and creates a separate run snapshot.

### History

- Completed Routine runs ordered by end date.
- Each item shows Routine name, dates, final score, Goal target, and achieved/not-achieved status.
- Tapping opens the preserved Results screen.
- Restart creates a new run and never modifies the History item.

The primary **Add Routine** action remains available from this destination.

## Create or edit Routine flow

### 1. Choose a starting point

- Blank Routine.
- Built-in template with a preview of Activities and defaults.

### 2. Routine details

- Name.
- Description.
- Minimum Goal score.
- Required start date for the first run.
- Required end date for the first run.

The end date must be after the start date. The UI should explain the number of days and any partial scoring cycles before final save when those rules are defined.

### 3. Select Activities

- Search bar.
- Reusable Activity list.
- Multi-select using checkmarks and text, not color alone.
- Selected count and summary.
- Each row may preview its default recurrence, target, Essential state, and reminder.
- **Create Activity** preserves the current search and selections.

### 4. Configure selected Activities

Configure one selected Activity at a time using cards, expansion panels, or a focused child screen:

- Scoring category: Daily, Weekly, or Monthly.
- For Daily Activities, recurrence of Every day or Selected weekdays.
- Required completion count for the applicable cycle.
- Essential toggle with short helper text.
- Reminder enabled state and time.
- A clear option to reset to the Activity defaults.

Do not place every configuration field inside the searchable picker list.

### 5. Review

- Routine identity and dates.
- Goal target.
- Selected Activities.
- Frequency categories and acceptance targets.
- Essential Activities.
- Reminder summary.
- Validation warnings.

### 6. Save

Saving creates or updates the reusable Routine definition and creates the first dated run when dates are supplied. Route the user to Active or Upcoming according to the start date and show a clear confirmation.

Confirm before discarding unsaved changes. A save failure must retain the entered form state.

## Create Activity flow

1. Name.
2. Description.
3. Icon from the built-in icon library.
4. Optional default configuration:
   - Scoring category: Daily, Weekly, or Monthly.
   - Daily recurrence: Every day or Selected weekdays.
   - Acceptance target.
   - Essential default.
   - Reminder default.
5. Save.
6. Return to the Activity picker with the new Activity selected and briefly highlighted.

The default configuration is copied into the Routine and remains editable there. Later changes to the Activity default must not silently rewrite existing Routine definitions or runs.

## To-Do tool

### List

- Incomplete first, completed below.
- Search or filter only when the list size justifies it.
- Visible Add action.
- Empty state with a single clear call to action.

### Create or edit

- Title.
- Optional description.
- Optional due date and time.
- Optional reminder.
- Save.
- Delete is available from Edit with confirmation and Undo where feasible.

To-Do completion is independent of Routine scoring.

## Reminder tool

### List

- Upcoming first.
- Delayed state is visible.
- Completed/dismissed history is optional for MVP and should remain lightweight.

### Create or edit

- Title.
- Optional description.
- Date and time.
- Approved repeat rule if repeating standalone reminders are in scope.
- Save.

Notification states include education, request, allowed, denied, permanently denied, schedule failure, and Open system settings.

## More

### Profile

- Avatar.
- Name.
- Date of birth.
- Optional weight and height.
- Metric/imperial unit presentation must be explicit.
- Save at the bottom.

Profile health measurements do not influence MVP scoring unless a later product decision explicitly defines that behavior.

### Tools

- Enable or disable To-Dos and Reminders.
- Disabling changes drawer and dashboard visibility only.
- Existing records remain stored.
- A clear message explains that data is preserved.

### Settings

- Appearance: System, Light, Dark.
- Notification permission and preferences.
- Accessibility and reduced-motion information.
- **How scoring works**.
- Privacy and local-data explanation.
- About and help.

Import/export appears here in V1.1, not in the MVP navigation.

## Results and Goal screen

The Results screen opens from a dashboard Results card or a History item.

### Content order

1. Routine name and completed date range.
2. Final score out of 100.
3. Goal target and clear achieved/not-achieved result.
4. Supportive motivation text.
5. Score breakdown by frequency category and configured Activity.
6. Compact calendar.
7. Restart action.

Do not use shame, broken-streak language, or a failure-dominant visual treatment when the Goal is missed.

### Scoring presentation

Use the PVRD method:

- Daily category: 60 points.
- Weekly category: 30 points.
- Monthly category: 10 points.
- Within a category, a normal Activity receives one share.
- Within a category, an Essential Activity receives two shares.
- Each Activity earns its allocated points in proportion to its acceptance-criteria completion.
- The category totals combine into the final score out of 100.
- The Goal is the minimum final score the user selected for that run.

The Results screen should explain contributions in plain language, for example: **Walk earned 20 of 40 points**. A separate **How scoring works** screen may explain the full method without cluttering daily screens.

The PVRD defines the core allocation clearly but does not settle empty categories, overachievement, partial cycles, mid-run configuration changes, backdated completions, time-zone changes, week start, or rounding. Keep those decisions explicitly unresolved until approved; do not invent behavior in UI copy or implementation.

### Calendar states

The compact calendar uses both color and non-color cues:

- **Achieved:** green/teal, check icon, and accessible label; all date-specific scheduled work was completed.
- **Partial:** amber, partial-progress icon, and accessible label; some but not all date-specific work was completed.
- **Missed:** coral/red, missed icon, and accessible label; date-specific scheduled work existed and none was completed after the date ended.
- **Rest:** neutral gray, rest icon, and accessible label; nothing was scheduled.
- **Future:** neutral outline and accessible label.

Weekly or monthly quota Activities must not make every unused day appear missed. Their success is evaluated at the applicable cycle level, while the calendar shows actual completions and date-specific obligations.

### Restart

- Open a date-selection step.
- Require new start and end dates.
- Show the saved Routine configuration and Goal target for confirmation.
- Create a new run snapshot.
- Preserve the previous Result unchanged.

Basic analytics may be added later. Do not include dead analytics controls in the MVP screen.

## Required UX states

Every applicable flow must design:

- Empty.
- Partially empty.
- Loading.
- Success.
- Validation error.
- Persistence or database failure.
- Notification permission denied and permanently denied.
- No search results.
- Unsaved changes.
- Date rollover while the app is open.
- Large text and screen-reader layout.
- Reduced motion.
- Light and dark themes.
- Non-gesture alternatives.

## Visual direction

The approved direction is **calm motivational productivity**:

- Primary brand color `#30A1C9`.
- Clear, rounded cards and generous spacing.
- Friendly iconography and concise encouragement.
- Restrained celebrations that communicate success.
- Accessible semantic colors with icons and labels.
- No childish gamification, shame, aggressive streak language, decorative clutter, or excessive gradients.
- One coherent visual system across Android and iOS, with platform-appropriate behavior.

The detailed visual tokens and component guidance live in `.stitch/DESIGN.md`.

## Approved decisions and open scoring rules

The product flow, navigation, gestures, reusable Routine model, Goal meaning, calendar statuses, release boundaries, and visual direction are approved.

Before the scoring engine is implemented, the user must still define or approve:

1. Empty Daily/Weekly/Monthly category behavior.
2. Whether completion above the target is capped or rewarded.
3. Partial-cycle behavior at Routine start and end.
4. Mid-run edits to criteria or Essential status.
5. Backdated completions and finalized Results.
6. Week-start preference.
7. Time-zone and daylight-saving behavior.
8. Final-score rounding.
