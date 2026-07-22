# Goalify Stitch UI Prompt Pack

**Status:** Ready for design generation  
**Date:** July 16, 2026  
**Target:** Android and iOS phone UI  
**Product flow:** `PRODUCT_UX_FLOW.md`  
**Design system:** `.stitch/DESIGN.md`

## How to use this pack

1. Create one Goalify project in Stitch.
2. Add `.stitch/DESIGN.md` as the project design-system context.
3. Start with the Master Project Context prompt.
4. Run the screen prompts in order so Stitch can reuse the same navigation, components, visual language, and sample data.
5. Ask Stitch to connect screens according to the Prototype Map.
6. Use the Final Consistency and Accessibility prompt after the full flow exists.

Generate mobile portrait screens around a modern 390 x 844 logical-pixel frame. The designs should be implementation-friendly for Flutter, but prompts intentionally avoid package, router, state-management, database, and platform-plugin decisions.

Do not ask Stitch to generate the whole product in one prompt. Create one coherent flow at a time, review it, and then continue.

## Master Project Context

```text
Design a high-fidelity mobile application named Goalify for Android and iOS.

Product purpose:
Goalify is an offline-first, privacy-first routine tracker that rewards consistency rather than perfect streaks. It combines reusable Routines, daily Activities, standalone To-Dos, and standalone Reminders. The experience must encourage a user to open the app at least once daily without guilt, pressure, or fragile streak mechanics.

Use only these user-facing product concepts:
- Activity: a reusable action such as Walk, Read, or Stretch, with a name, description, icon, and visible default recurrence, acceptance target, Essential, and reminder configuration.
- Routine: a reusable definition containing configured Activities. Starting or restarting it creates a separate run with required start and end dates. Previous Results remain unchanged.
- Goal: the minimum final score the user wants to achieve for a Routine run. Goal is not a parent container.

Navigation:
- Bottom navigation has exactly Today, Routines, and More.
- A drawer is available from root screens and lists enabled tool shortcuts only, initially To-Dos and Reminders.
- The drawer does not duplicate Today, Routines, History, More, Profile, or Settings.
- Root screens may show the drawer button; nested screens show Back instead.

Visual direction:
Use the supplied Goalify Calm Momentum DESIGN.md. The style is calm motivational productivity: friendly, polished, spacious, and encouraging without becoming childish. Primary brand color is #30A1C9. Use the darker accessible action blue from DESIGN.md for filled buttons. Use rounded cards, clear hierarchy, concise copy, restrained success motion, accessible light and dark modes, and coherent iconography.

Accessibility:
- Never use color as the only status signal.
- Use check, partial, missed, rest, and future icons or patterns with labels.
- Every swipe action has a visible completion control or overflow-menu alternative.
- Use at least 48px interactive heights and layouts that can survive large text.
- Provide reduced-motion equivalents.
- Preserve strong contrast and meaningful semantic labels.

Accepted dashboard gestures for an English left-to-right layout:
- Routine Activity: left-to-right Complete; right-to-left Mute today.
- To-Do: left-to-right Complete; right-to-left Edit or reschedule.
- Standalone Reminder: left-to-right Done; right-to-left Delay.
- Completed item: left-to-right Undo.
These are logical start/end actions and should mirror for right-to-left locales.

Completion behavior:
Completed items remain visible, animate lower in their section, and use a bright but accessible success treatment with a check icon and Completed label. Offer Undo. Avoid hiding completed work immediately.

Scoring presentation:
The PVRD allocates 60 points to Daily Activities, 30 to Weekly Activities, and 10 to Monthly Activities. Within each category a normal Activity receives one share and an Essential Activity receives two shares. Each Activity earns its allocated points in proportion to its acceptance target. The total is a score out of 100. The Goal is the selected minimum target score.

MVP exclusions:
Do not show active import/export, Routine sharing, custom gallery images, advanced analytics, social features, AI tools, advertisements, or premium upsells. Import/export begins in V1.1; sharing and expanded analytics are future work.

Use a stable sample user named Ali and consistent sample content across every generated screen:
- Active Routine: Morning Momentum, July 16 to August 15, Goal 75.
- Activities: Morning Walk, Stretch, Read 20 Minutes, Drink Water.
- Upcoming Routine: Exam Focus, August 20 to September 20, Goal 80.
- Saved Routine: Weekend Reset.
- Historical Routine run: Get Fit, June 1 to June 30, Goal 75, final score 80, with Walk, Stretch, Gym, and Health Check.
- To-Do: Buy groceries.
- Standalone Reminder: Call Mom at 2:00 PM.

Keep every screen part of one coherent design system and do not redesign navigation or components between prompts.
```

## Prompt 1 - Welcome, privacy, and profile onboarding

```text
Using the established Goalify project context and DESIGN.md, create a three-screen first-run onboarding flow.

Screen 1: Welcome
- Goalify wordmark or simple icon treatment.
- Headline: “Build consistency, not perfect streaks.”
- Short explanation that Goalify combines Routines, To-Dos, and Reminders.
- Calm supporting illustration made from simple abstract shapes or icons, not a character mascot.
- Primary Continue action. Do not provide a Skip action; the required privacy acknowledgement must not be bypassed.

Screen 2: Your data stays here
- Clear privacy icon and concise explanation that all data is stored locally on this device.
- Explain that V1.0 has no cloud recovery and device loss or reset may lose data.
- Acknowledgement checkbox using plain language.
- Continue disabled until acknowledged.
- Keep the tone transparent, not alarming.

Screen 3: Create your profile
- Avatar picker using generated initials or built-in avatar choices.
- Name, date of birth, optional weight, and optional height.
- Show explicit metric units and a small unit-change control.
- Explain that weight and height are optional and reserved for future motivation and analytics; they do not affect current scoring.
- Primary “Finish setup” action fixed safely near the bottom.

Show validation, keyboard-safe layout, large-text resilience, and light mode. Provide a dark-mode variant for the privacy screen.
```

## Prompt 2 - First-use Today empty state

```text
Create the first-use Today screen after onboarding when the user has no Routine, To-Do, or Reminder yet.

Requirements:
- Bottom navigation: Today selected, Routines, More.
- Root app bar with drawer button, title Today, current date, and avatar or compact contextual action on the right.
- A friendly greeting to Ali.
- A calm empty-state card explaining that a Routine groups Activities and works toward a Goal score.
- Primary action: “Create a Routine.”
- Secondary action: “Start from a template.”
- Smaller shortcuts: “Add To-Do” and “Add Reminder.”
- Do not show empty headings or blank cards for every section.
- Do not show disabled future features.

Use the Goalify Calm Momentum design system, generous spacing, and concise encouraging copy.
```

## Prompt 3 - Populated Today dashboard

```text
Create a populated Today dashboard for Ali using the shared sample data.

Structure:
- Greeting, date, and compact “3 of 6 complete today” progress summary.
- An active Routine section for Morning Momentum with a small Goal progress indicator showing the current run is moving toward Goal 75.
- Activity cards for Morning Walk, Stretch, Read 20 Minutes, and Drink Water.
- Each Activity card shows icon, Activity name, Routine name, compact today-specific schedule, reminder state when relevant, visible completion control, and overflow menu.
- To-Dos section with Buy groceries.
- Reminders section with Call Mom at 2:00 PM.
- Completed section sorted below incomplete work, containing one completed Activity in a bright success-soft card with a check icon, Completed label, and Undo affordance.

Make the screen useful at a glance. Keep scoring details out of daily cards. Avoid a dense analytics dashboard, large decorative hero, or excessive progress rings.

Also create a dark-mode variant with accessible contrast.
```

## Prompt 4 - Dashboard swipe and completion states

```text
Create a focused interaction board showing Goalify dashboard cards in their important gesture and state variants. Keep the same card component and sample data as the Today screen.

Show:
1. Routine Activity swiped start-to-end, revealing Complete with check icon.
2. Routine Activity swiped end-to-start, revealing Mute today with muted-bell icon. Explain that it only cancels today's remaining notification.
3. To-Do swiped end-to-start, revealing Edit or reschedule.
4. Standalone Reminder swiped end-to-start, revealing Delay.
5. Delay bottom sheet with 10 minutes, 1 hour, Tomorrow morning, and Custom.
6. Completed card moved lower with success treatment and Undo.
7. Save-failure state restoring the incomplete card and showing a concise retry message.
8. Reduced-motion version using immediate state change instead of card movement.

Every action must also appear through a visible control or overflow menu. Do not make gesture discovery depend on instructional text alone.
```

## Prompt 5 - Tool drawer and More hub

```text
Create two related root-level screens.

Screen A: Open tool drawer
- Header with Ali's avatar, “Good morning,” Ali's name, and a compact “3 of 6 done today” line.
- Enabled tool links only: To-Dos and Reminders.
- Manage tools link at the bottom.
- Do not list Today, Routines, History, More, Profile, or Settings.
- The underlying Today screen remains visible behind a subtle scrim.

Screen B: More
- Bottom navigation with More selected.
- Profile summary card with Edit profile.
- Tools row showing enabled state and Manage tools.
- Appearance row showing System.
- Notifications row with permission status.
- Accessibility and reduced-motion information.
- How scoring works.
- Privacy and local data.
- About and help.
- Do not show import/export in MVP.

The drawer is a shortcut surface while More is the management and settings destination. Make this distinction visually clear.
```

## Prompt 6 - Routines hub

```text
Create the Routines destination with a stable top-level switch between Current, Saved, and History.

Current view:
- Active subsection with Morning Momentum, July 16 to August 15, Goal 75, current score progress, and next activity.
- Upcoming subsection with Exam Focus, August 20 to September 20, Goal 80.
- Cards clearly distinguish active and upcoming states without using color alone.

Saved view:
- Reusable Routine definitions such as Weekend Reset.
- Each card shows Activity count, default Goal target, and compact configuration summary.
- Actions: Start, Edit, and overflow for Save as Routine or Delete.
- Explain briefly that starting creates a new dated run and does not erase previous Results.

History view:
- Completed runs ordered by end date.
- Each item shows Routine name, date range, final score, Goal target, and achieved/not-achieved status.
- Tapping opens Results.

Keep a prominent Add Routine action available. Also show meaningful empty states for each view as secondary frames.
```

## Prompt 7 - Create Routine details

```text
Create the first two steps of the Create Routine flow.

Step 1: Choose a starting point
- Blank Routine card.
- Built-in templates with compact preview: Morning Energy, Study Focus, and Gentle Fitness.
- Template preview explains included Activities and that everything remains editable.

Step 2: Routine details
- Name and description.
- Minimum Goal score input using a clear 1-100 control with direct numeric entry; sample Goal 75.
- Required start date and required end date.
- Show the calculated run duration.
- Explain Goal in one sentence: “The minimum score you want to reach by the end of this Routine.”
- Continue action at the bottom.
- Validation for missing name, invalid score, missing dates, and end date before start date.
- Unsaved-changes confirmation when navigating back.

Use progressive disclosure and avoid turning the page into a long technical form.
```

## Prompt 8 - Activity picker

```text
Create the Select Activities step for the Routine flow.

Requirements:
- Search bar at the top.
- Activity list with icon, name, short description, and compact preview of default configuration.
- Multi-selection using clear checkmarks, row state, and a selected-count summary; do not rely on highlight color alone.
- Sample Activities: Morning Walk, Stretch, Read 20 Minutes, Drink Water, Meditation, Journal.
- Persistent “Create Activity” action.
- Bottom action: “Configure 4 Activities.”
- Show no-search-results and empty-library states as variants.
- Preserve selected Activities if the user opens Create Activity and returns.

Default recurrence, target, Essential state, and reminder are previews only. The user configures the copied values for this Routine in the next step.
```

## Prompt 9 - Create Activity and default configuration

```text
Create a nested Create Activity flow opened from the Activity picker.

Screen 1: Activity identity
- Name.
- Description.
- Built-in icon-library picker with search and categories.
- Default icon if none is selected.
- No gallery-image option in MVP.

Screen 2: Optional default configuration
- Scoring category: Daily, Weekly, or Monthly.
- When Daily is selected, recurrence choice: Every day or Selected weekdays.
- Acceptance target count appropriate to the selected category and cycle.
- Essential default with helper text: “Essential Activities receive two scoring shares within their category.”
- Optional reminder and time.
- Explain that these are reusable starting defaults and may be changed inside each Routine.

Screen 3: Save result
- Return to the existing Activity picker.
- Preserve earlier search and selections.
- New Activity is selected and briefly highlighted with a “New” label that is not color-only.

Show validation and save-failure states without losing entered data.
```

## Prompt 10 - Configure selected Activities

```text
Create the Configure Activities step after four Activities have been selected.

Use a mobile-friendly list of expandable Activity cards or a focused one-at-a-time editor. Do not place every field directly inside the search list.

For each configured Activity include:
- Activity identity and “Using Activity defaults” summary.
- Scoring category: Daily, Weekly, or Monthly.
- Every day or Selected weekdays when the Daily category is selected; cycle settings when Weekly or Monthly is selected.
- Required completion count.
- Essential toggle and concise score-impact helper text.
- Reminder enabled state and time.
- Reset to Activity defaults.
- Clear valid/invalid state.

Use sample configurations:
- Morning Walk: Daily, target 1 per day, Essential, reminder 7:00 AM.
- Stretch: Daily, target 1 per day, normal.
- Read 20 Minutes: Weekly, target 5 per week, normal, reminder 8:00 PM.
- Drink Water: Daily, target 1 per day, normal.

Include a sticky but non-obstructive Continue to review action. Make the form understandable to someone who has never seen scoring buckets.
```

## Prompt 11 - Routine review, save, and detail

```text
Create three connected screens.

Screen A: Review Routine
- Morning Momentum identity and description.
- July 16 to August 15.
- Goal 75.
- Four configured Activities grouped by Daily or Weekly category.
- Essential and reminder indicators.
- Edit links for details and Activities.
- Primary action: Save and start.

Screen B: Save confirmation
- Short success state confirming the reusable Routine was saved and its first dated run was created.
- Route to Active or Upcoming based on start date.
- Avoid a full-screen celebration for a configuration save.

Screen C: Active Routine detail
- Routine name, dates, Goal 75, progress toward final score, days remaining.
- Activity list with compact configuration summaries.
- Upcoming schedule and reminders.
- Edit and overflow actions.
- Explain that changing the saved Routine does not rewrite this active run or past Results.

Show a save-failure variant that preserves form state and offers Retry.
```

## Prompt 12 - To-Do tool

```text
Create the standalone To-Do tool opened from the drawer.

List screen:
- Root-style app bar with Back or close appropriate to the navigation stack, title To-Dos, and Add action.
- Incomplete items first and completed items below.
- Sample item Buy groceries.
- Visible completion control, overflow menu, and accepted swipe behavior.
- Empty state and all-complete state.

Create/edit screen:
- Title.
- Optional description.
- Optional due date and time.
- Optional reminder.
- Save at the bottom.
- Delete inside Edit with confirmation.

To-Dos do not contribute to Routine score. Keep the visual language consistent with Activity cards while maintaining a clear tool identity.
```

## Prompt 13 - Standalone Reminder tool

```text
Create the standalone Reminder tool opened from the drawer.

List screen:
- Upcoming Reminders ordered by time.
- Sample Call Mom at 2:00 PM.
- Clearly show delayed state when applicable.
- Visible Done control and overflow menu.
- Right-to-left Delay gesture with visible alternative.
- Empty state.

Create/edit screen:
- Title.
- Optional description.
- Date and time.
- Simple repeat rule only if it can remain understandable.
- Save at the bottom.

Permission-state frames:
- Education before the first OS request.
- Permission denied.
- Permanently denied with Open system settings.
- Schedule failure with Retry.

Delay sheet:
- 10 minutes, 1 hour, Tomorrow morning, Custom.
- Explain that Delay changes only the next occurrence.
```

## Prompt 14 - Results and Goal

```text
Create the Goalify Results screen for the historical Get Fit run defined in the shared sample data. This is intentionally a separate preserved run using the PVRD worked example, not the active Morning Momentum sample.

Use consistent sample outcome:
- Date range: June 1 to June 30.
- Final score: 80 out of 100.
- Goal target: 75.
- Goal achieved.

Content hierarchy:
1. Routine name and completed date range.
2. Large score 80/100.
3. Goal 75 with a clear achieved icon and supportive line such as “You reached your Goal with steady progress.”
4. Motivation text that celebrates consistency without mentioning streaks.
5. Score breakdown.
6. Compact calendar.
7. Restart Routine button.

Score breakdown must reflect the PVRD example:
- Daily category: 60 available points.
- Walk is Essential and receives 40 available points; 50% completion earns 20.
- Stretch is normal and receives 20; full completion earns 20.
- Weekly category: Gym earns 30 of 30.
- Monthly category: Health Check earns 10 of 10.
- Final score is 80 of 100.

Show explicit earned-of-available labels and a “How scoring works” link. Do not use a misleading decorative chart that hides the actual contribution.

Calendar:
- Achieved uses green/teal plus check.
- Partial uses amber plus partial icon.
- Missed uses coral/red plus missed icon.
- Rest uses neutral gray plus rest icon.
- Future uses neutral outline.
- Include a legend and accessible labels.
- Weekly and monthly quotas must not make every unused day appear missed.

Also create a Goal-not-achieved variant using supportive language and no failure-dominant red hero treatment.
```

## Prompt 15 - History and Restart

```text
Create two connected screens from Routines > History.

Screen A: History
- Completed Routine runs ordered by end date.
- Cards show Routine name, date range, final score, Goal target, and achieved/not-achieved status.
- Include Get Fit 80/100, Goal 75, matching the preserved PVRD worked-example Result.
- Include another lower-score example without shame-based presentation.
- Search or filter only if it remains lightweight.
- Tapping a card opens its preserved Results.

Screen B: Restart Routine
- Explain that Restart creates a new run and preserves the existing Results.
- New required start and end dates.
- Saved Routine configuration preview.
- Goal target visible and confirmable.
- Primary “Start new run” action.
- Option to edit or Save as Routine before starting without overwriting the historical run.

Do not place History under More and do not treat Restart as resetting old data.
```

## Prompt 16 - Profile, tool management, and scoring explanation

```text
Create three More-area child screens.

Screen A: Edit profile
- Avatar, name, date of birth, optional weight, optional height.
- Explicit metric/imperial unit presentation.
- Explain that health measurements are optional and do not affect current score.
- Save at bottom.

Screen B: Manage tools
- To-Dos and Reminders with enable/disable controls.
- Explain that disabling hides dashboard and drawer shortcuts but preserves all saved records.
- Provide an Open action for enabled tools.
- Do not imply deletion.

Screen C: How scoring works
- Plain-language explanation of Daily 60, Weekly 30, Monthly 10.
- Normal Activity equals one share; Essential Activity equals two shares inside its category.
- Simple worked example using accessible diagrams and text.
- Explain that the Goal is the minimum final score selected for a Routine run.
- Keep the page educational but concise; it should not feel like financial analytics.
```

## Prototype Map

Ask Stitch to connect the generated screens using this flow:

```text
Connect the existing Goalify screens into an interactive prototype without changing their visual design.

First run:
Welcome -> Local privacy -> Create profile -> Today empty state.

Create Routine:
Today empty state or Routines Add -> Choose blank/template -> Routine details -> Select Activities -> Create Activity when requested -> Configure Activities -> Review -> Save confirmation -> Active or Upcoming Routine detail.

Daily use:
Today -> Complete Activity -> Completed state -> Undo.
Today -> Mute today through swipe or overflow.
Today -> Drawer -> To-Dos or Reminders.
Reminder -> Delay sheet.

Routine management:
Routines Current -> Routine detail.
Routines Saved -> Start -> date selection -> new Current run.
Routines History -> Results -> Restart -> new run.

Settings:
More -> Profile, Manage tools, Appearance, Notifications, How scoring works, Privacy, About.
Manage tools controls drawer and dashboard tool visibility without deleting records.

Results:
Today Results card or History item -> Results -> Restart.

Preserve bottom navigation only on root Today, Routines, and More screens. Nested screens use Back and do not show a drawer button.
```

## Final consistency and accessibility pass

```text
Review every Goalify screen in this project as one design system. Do not redesign the product. Correct inconsistencies and produce the smallest necessary variants.

Audit and fix:
- Bottom navigation contains exactly Today, Routines, and More.
- Drawer contains enabled tool shortcuts only.
- Root app bars use the drawer action; child screens use Back, never both.
- #30A1C9 remains the recognizable brand accent.
- Filled primary buttons use the accessible darker action blue with adequate text contrast.
- The same card, field, button, chip, spacing, radius, icon, and typography language is reused.
- All controls meet mobile touch-target expectations.
- Large text does not clip or hide actions.
- Every swipe has a visible alternative.
- Red, amber, and green statuses also use icons and labels.
- Completed cards are rewarding, remain visible, and sort below incomplete work.
- Dark mode preserves contrast and semantic meaning.
- Reduced-motion variants preserve feedback without movement.
- Empty, loading, validation, save-failure, permission-denied, and no-results states exist where applicable.
- Copy avoids shame, broken streaks, or pressure.
- MVP screens do not expose import/export, sharing, gallery images, advanced analytics, or monetization.

Finally, play through the prototype paths and identify any dead end, inconsistent Back behavior, duplicated destination, or action with no confirmation or recovery state.
```

## Optional future prompts - do not mix into MVP

### V1.1 import and export

```text
Extend the established Goalify More > Data and privacy area for V1.1 only. Design local Export and Import flows with format/version information, replace-or-merge decision left visibly unresolved, confirmation, progress, cancel, invalid file, incompatible version, success, failure, and no-partial-restore states. Maintain the offline privacy model and do not imply cloud sync.
```

### Future Routine sharing

```text
Explore a future Share Routine flow that shares only a reusable Routine definition and its Activity configuration, never profile information, completion history, Results, or private local records. Keep this work visually separate from the MVP prototype and label it Future concept.
```

### Future analytics

```text
Explore a future Results analytics extension using preserved Routine-run history. Show trends that encourage sustainable consistency rather than streak pressure. Every chart must have a readable text summary and accessible labels. Keep this work separate from the MVP prototype and label it Future concept.
```
