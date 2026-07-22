---
version: alpha
name: Goalify Calm Momentum
description: Calm motivational productivity for an offline, privacy-first routine tracker.
colors:
  primary: "#30A1C9"
  primary-action: "#0F6F90"
  primary-soft: "#DDF3FA"
  on-primary: "#FFFFFF"
  on-primary-brand: "#0C2B35"
  success: "#23856D"
  success-soft: "#DDF4EC"
  partial: "#B56E00"
  partial-soft: "#FFF1D6"
  missed: "#B84C55"
  missed-soft: "#FCE5E7"
  background: "#F5F9FA"
  surface: "#FFFFFF"
  surface-muted: "#EAF1F3"
  text: "#14272E"
  text-muted: "#526970"
  outline: "#B9C9CE"
  focus: "#6B5CC5"
  dark-background: "#0D1B20"
  dark-surface: "#15272D"
  dark-surface-muted: "#20353C"
  dark-text: "#EDF7F9"
  dark-text-muted: "#B7C9CE"
  dark-outline: "#486069"
typography:
  display:
    fontFamily: Inter
    fontSize: 32px
    fontWeight: 700
    lineHeight: 1.15
    letterSpacing: -0.02em
  title:
    fontFamily: Inter
    fontSize: 24px
    fontWeight: 700
    lineHeight: 1.2
    letterSpacing: -0.01em
  headline:
    fontFamily: Inter
    fontSize: 20px
    fontWeight: 650
    lineHeight: 1.3
    letterSpacing: -0.005em
  body:
    fontFamily: Inter
    fontSize: 16px
    fontWeight: 400
    lineHeight: 1.5
    letterSpacing: 0em
  body-small:
    fontFamily: Inter
    fontSize: 14px
    fontWeight: 400
    lineHeight: 1.45
    letterSpacing: 0em
  label:
    fontFamily: Inter
    fontSize: 14px
    fontWeight: 600
    lineHeight: 1.3
    letterSpacing: 0.01em
rounded:
  sm: 8px
  md: 12px
  lg: 16px
  xl: 24px
  full: 9999px
spacing:
  xs: 4px
  sm: 8px
  md: 12px
  lg: 16px
  xl: 24px
  2xl: 32px
components:
  button-primary:
    backgroundColor: "{colors.primary-action}"
    textColor: "{colors.on-primary}"
    typography: "{typography.label}"
    rounded: "{rounded.md}"
    height: 48px
    padding: 16px
  button-secondary:
    backgroundColor: "{colors.primary-soft}"
    textColor: "{colors.text}"
    typography: "{typography.label}"
    rounded: "{rounded.md}"
    height: 48px
    padding: 16px
  card:
    backgroundColor: "{colors.surface}"
    textColor: "{colors.text}"
    rounded: "{rounded.lg}"
    padding: 16px
  card-completed:
    backgroundColor: "{colors.success-soft}"
    textColor: "{colors.text}"
    rounded: "{rounded.lg}"
    padding: 16px
  input:
    backgroundColor: "{colors.surface}"
    textColor: "{colors.text}"
    rounded: "{rounded.md}"
    height: 52px
    padding: 16px
  chip:
    backgroundColor: "{colors.surface-muted}"
    textColor: "{colors.text}"
    typography: "{typography.label}"
    rounded: "{rounded.full}"
    height: 36px
    padding: 12px
  bottom-navigation:
    backgroundColor: "{colors.surface}"
    textColor: "{colors.text-muted}"
    height: 72px
  focus-ring:
    backgroundColor: "{colors.focus}"
    rounded: "{rounded.md}"
    width: 3px
---

# Goalify Calm Momentum

## Overview

Goalify should feel like a calm, encouraging companion that helps users return daily without punishing imperfect progress. The visual personality combines the clarity of a modern productivity app with the warmth of a wellness product.

The interface is:

- Calm rather than clinical.
- Motivational rather than competitive.
- Friendly rather than childish.
- Spacious rather than sparse.
- Polished without decorative excess.
- Consistent across Android and iOS while respecting platform behavior.

Use short supportive messages such as “Nice progress,” “You moved forward today,” and “Ready for another step?” Avoid shame, failure-dominant screens, broken-streak language, trophies everywhere, confetti on minor actions, or pressure to maintain perfection.

## Colors

The brand is anchored by **Goalify Blue `#30A1C9`**. It is the recognizable accent for selected navigation, progress, icons, highlights, and larger brand moments.

Do not place normal-sized white text directly on `#30A1C9`; that combination is not strong enough for accessible body-label contrast. Use the darker **primary action `#0F6F90`** for filled buttons with white text, or use dark text on the brand blue.

Semantic states use distinct hues and must always include an icon, label, shape, or pattern:

- **Success `#23856D`:** completed and achieved.
- **Partial `#B56E00`:** meaningful progress that has not met the current target.
- **Missed `#B84C55`:** a past scheduled obligation with no completion; use sparingly and supportively.
- **Neutral:** rest days, future dates, disabled controls, and secondary information.
- **Focus `#6B5CC5`:** visible keyboard or switch-access focus, distinct from status colors.

In dark mode, use the dark background and surface tokens rather than inverting the light palette mechanically. Keep brand blue recognizable, preserve contrast, and avoid glowing neon treatments.

## Typography

Use Inter for design generation and a comparable platform sans-serif if Inter is unavailable during implementation. Typography should remain highly readable at increased text sizes.

- Display is reserved for major score or onboarding moments.
- Title identifies screens and Results summaries.
- Headline identifies sections and Routine cards.
- Body is the default explanatory and form text.
- Labels identify buttons, chips, compact metadata, and statuses.

Use sentence case. Avoid all-caps controls, very light font weights, overly tight line spacing, or truncating essential information. App-bar subtitles must remain short; put longer explanation in the body.

## Layout

Use a 4px base rhythm with the defined spacing scale. Typical phone screens use:

- 16px horizontal page padding.
- 24px between major sections.
- 12-16px between related cards.
- 8px between labels and supporting information.
- At least 48px interactive height for primary controls.

Prefer one comfortable column on phones. Keep the primary action reachable near the bottom without covering content. Forms use clear groups and helper text; do not compress recurrence, scoring, and reminders into one dense picker row.

Bottom navigation contains exactly Today, Routines, and More. The drawer is reserved for enabled tool shortcuts and must not duplicate primary destinations.

## Elevation & Depth

Create depth through tonal surfaces, borders, and modest shadow rather than floating every element.

- Page background uses the background token.
- Standard content uses surface cards.
- Selected or completed content uses a semantic soft surface.
- Use a subtle border when cards need separation in dark mode.
- Reserve stronger elevation for temporary menus, bottom sheets, date/time pickers, and swipe action panes.

Avoid heavy black shadows, glassmorphism, blurred color clouds, and stacked nested cards.

## Shapes

Use rounded geometry to feel approachable without becoming toy-like.

- 12px for inputs and standard buttons.
- 16px for cards and bottom sheets.
- 24px for major Results or onboarding panels.
- Full rounding for chips, compact progress indicators, and avatar treatments.

Icons should be simple, filled or rounded line icons with consistent visual weight. Activity icons come from a coherent built-in icon library in MVP.

## Components

### Activity and To-Do cards

- Leading icon, clear title, compact supporting text, visible completion control, and trailing menu.
- Swipe actions may reveal a colored action pane, but the same action must exist in the menu.
- Incomplete items use the standard surface.
- Completed items move lower and use `success-soft`, a check icon, and a Completed label.
- Keep the completed highlight bright enough to feel rewarding but distinct from the calendar Achieved cell.

### Routine cards

- Show name, date range, Goal target, progress, and state.
- Use small chips for Active, Upcoming, Saved, or Completed.
- Do not overload cards with the full Activity configuration.

### Results score

- Make the final score the strongest element.
- Show the Goal target immediately beside or below it.
- Pair achieved/not-achieved status with supportive text and an icon.
- Score breakdowns use clear rows or bars with explicit “earned of available points” labels.
- Calendar cells include icon or pattern cues in addition to color.

### Forms

- Labels remain visible after entry.
- Required dates, Goal score, and validation are explicit.
- The bottom Save action remains reachable but does not obscure the last field.
- Use progressive disclosure for recurrence, acceptance criteria, Essential status, and reminders.

### Navigation and drawer

- Bottom navigation has three destinations only.
- Root app bars may show the drawer button.
- Child app bars show Back instead.
- Drawer header contains avatar, welcome, name, and an optional compact daily-progress line.
- Drawer body lists enabled tools only and ends with Manage tools.

### Motion

- Motion communicates completion, sorting, continuity, or Results.
- Completion feedback should feel immediate and finish quickly.
- Use restrained scale, fade, progress, and list-reorder motion.
- Respect reduced-motion preferences by replacing movement with instant state changes and concise feedback.
- Never delay completion or saving for an animation.

## Do's and Don'ts

### Do

- Use `#30A1C9` consistently as the recognizable brand accent.
- Use `#0F6F90` for accessible filled primary actions with white text.
- Keep actions visible and understandable without gestures.
- Use icons and labels alongside red, amber, and green states.
- Preserve generous touch targets and text scaling.
- Keep daily progress encouraging even when the Goal is not reached.
- Design empty, error, denied-permission, dark, and reduced-motion states.
- Make saved Routines, dated runs, and historical Results visually distinct.

### Don't

- Do not use streak-loss warnings or shame-based copy.
- Do not use color as the only status signal.
- Do not put core tabs inside the drawer.
- Do not expose technical data-model names.
- Do not show import/export, sharing, gallery icons, or analytics as active MVP features.
- Do not use large decorative gradients, excessive confetti, glass effects, or multiple competing accent colors.
- Do not hide primary completion behind swipe alone.
- Do not let edited Routine defaults rewrite past Results.

