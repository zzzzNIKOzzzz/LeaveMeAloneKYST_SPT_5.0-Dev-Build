![SPT](https://img.shields.io/badge/SPT-5.0.0-blue?style=flat-square)
![EFT](https://img.shields.io/badge/EFT-1.1.5.1.47510-lightgrey?style=flat-square)
![BepInEx](https://img.shields.io/badge/BepInEx-6.0.0--be.788-orange?style=flat-square)
![IL2CPP](https://img.shields.io/badge/Runtime-IL2CPP-purple?style=flat-square)
![.NET](https://img.shields.io/badge/.NET-6.0-512BD4?style=flat-square)
![License](https://img.shields.io/badge/License-Custom%20%2F%20SPT--only-red?style=flat-square)
![Status](https://img.shields.io/badge/Status-Working-brightgreen?style=flat-square)

# LeaveMeAloneKYST

Standalone-порт мода **BushWhacker** (автор оригинала — Devraccoon, на основе CWX BushWhacker) под **SPT 5.0** (EFT 1.1.5, BepInEx 6 IL2CPP).

Отключает замедление от кустов и болот в Escape from Tarkov. Кусты и болота больше не тормозят — можно спокойно бежать через них, не теряя скорость.

## Возможности

- **Кусты** (`filbert` / `fibert` / `swamp`) — отключаются через `SetEnabledUniversal` и `SetActive`.
- **Болота** (`BoxCollider` с именем `"Swamp_collider"`) — отключаются через `SetEnabledUniversal`.
- **Обработка при старте рейда** — логика применяется в момент `GameWorld.OnGameStarted()`, когда сцена рейда уже полностью загружена (через Harmony postfix).
- **Конфиг** — можно включать/отключать мод целиком через BepInEx Configuration Manager.
- **Standalone** — не требует оригинального MegaMod, работает как самостоятельный плагин.

## Требования

- **SPT 5.0.0** (EFT 1.1.5.1.47510)
- **BepInEx 6.0.0-be.788** (IL2CPP, .NET 6)

## Установка

1. Скачай последний релиз. `LeaveMeAloneKYST.dll`
2. Помести `LeaveMeAloneKYST.dll` в `BepInEx/plugins/LeaveMeAloneKYST/`.
3. Запусти игру.

## Конфигурация

Файл конфига: `BepInEx/config/com.hazelify.leavemealonekyst.cfg`

```ini
[General]

## Отключает замедление от кустов и болот.
# Setting type: Boolean
# Default value: true
Enabled = true
