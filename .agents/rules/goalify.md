# Goalify workspace rule

Always apply the shared repository guidance in @../../AGENTS.md.

For Flutter features, enhancements, migration work, architecture decisions, or substantial Flutter explanations, use the `flutter-architecture-expert` skill.

After implementation is stable, or whenever the user asks for a review, use the separate read-only `flutter-session-reviewer` skill. Do not review concurrently with changing implementation files.

Treat `.agents/skills/` and this `.agents/rules/` file as Antigravity configuration. Do not copy Codex-only TOML fields or handoff mechanisms into Antigravity metadata.
