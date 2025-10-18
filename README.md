# Title: Pulse TD — Game Description & Mechanics
# Applies to: repo
# Description: High-level context so the AI understands the game world and core mechanics. No tech or coding rules here.

## Game Overview
- **Title:** Pulse
- **Genre:** 2D tower defense for iOS/Android (portrait or landscape TBD)
- **Visual Tone:** Clean, readable anime/cartoon-inspired look with strong silhouettes
- **Performance Goal:** Smooth mobile experience targeting 60 FPS

## Core Fantasy
Defend a vulnerable **Heart** at the center of the map. A **Hero** is tethered to the Heart by a lifeline; staying within the tether range empowers the Hero’s abilities. Enemies spawn in waves and traverse predetermined paths toward the Heart. The player builds and upgrades towers, guides the Hero within range, and spends a shared resource called **Pulse** to survive escalating waves.

## Core Mechanics
- **Waves & Paths**
  - Enemies spawn in increasingly difficult **waves**.
  - Paths are built from **waypoints**; enemies follow them to reach the Heart.
  - Some waves introduce elites/minibosses and new resistances or movement quirks.

- **Buildable Tiles & Placement**
  - The map exposes **buildable cells** where towers can be placed.
  - Placement respects blocking rules (no hard path blocking unless a rule explicitly allows it).
  - Sell/refund rules and build times are configurable per tower type.

- **Towers**
  - Distinct roles (e.g., **Damage**, **Slow/Control**, **Support/Buffer**, **Splash**).
  - Each tower has **range**, **fire rate**, **damage type**, and **targeting** (first/last/strongest/closest).
  - **Upgrade paths**: branching tiers that modify stats, effects (e.g., bleed, burn, armor shred), or targeting AI.

- **Hero & Tether**
  - The **Hero** moves freely but must remain within the **tether radius** of the Heart.
  - Exceeding the radius is disallowed; the radius can be **upgraded** over the run.
  - The Hero has **active abilities** (cooldowns) and **passive auras** that benefit nearby towers.
  - Risk–reward: repositioning the Hero for clutch saves vs. staying central for global buffs.

- **Heart**
  - The **Heart** has health; enemies drain it on contact.
  - Optional **Heart pulses**: periodic area effects (e.g., brief slow or heal) that can be upgraded.

- **Economy (Pulse)**
  - **Pulse** is the universal resource for building, upgrading, and certain abilities.
  - Earned from kills, wave-completion bonuses, and optional interest/bounty modifiers.
  - **Spending tension**: balancing early tower spam vs. saving for key upgrades or tether range.

- **Progression & Difficulty**
  - Each wave increases enemy **HP**, **speed**, or **resistances**.
  - Difficulty modifiers: multi-lane waves, shielded runners, armor-stacked tanks, aerial units (if allowed).
  - Boss waves introduce mechanics checks (e.g., burst DPS, sustain, control).

- **UI/Feedback Essentials**
  - Clear tower ranges, tether radius, enemy path previews, and next-wave hints.
  - Readable damage types/resistances and upgrade deltas (before/after stats).

## Design Pillars
1. **Clarity over clutter:** readable sprites, clear ranges, distinct roles.
2. **Meaningful choices:** placement vs. upgrades, Hero risk–reward, Pulse budgeting.
3. **Composable depth:** simple base rules that combine into advanced strategies (synergies, auras, debuffs).
