# Goalify workspace rule

Always apply the shared repository guidance in @../../AGENTS.md.
Use @../../docs/AGENT_TESTING_STRATEGY.md for test selection, ownership,
consolidation, execution, reporting, and review.

For Flutter features, enhancements, migration work, architecture decisions, or substantial Flutter explanations, use the `flutter-architecture-expert` skill.

Use the separate read-only `flutter-session-reviewer` skill after the user
verifies the implementation and test finalization stops, or earlier when the
user explicitly requests a provisional review. Do not review concurrently with
changing implementation files.

Treat `.agents/skills/` and this `.agents/rules/` file as Antigravity configuration. Do not copy Codex-only TOML fields or handoff mechanisms into Antigravity metadata.
