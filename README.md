# Realm-of-Bones-Bears
An RPG where you embark on a thrilling journey. Spawn into a mystical world, gear up and prepare for an epic adventure. Battle a fierce skeleton, tame a mighty bear, and seek the key to unlock the portal to your destiny

This Unity project is an interactive game featuring a comprehensive inventory system, dynamic enemy AI, and responsive player controls. It includes a variety of scripts to manage gameplay, including player movement, camera control, item inventory, enemy behavior, and item interaction.

## Features

- **Player Movement**: Utilize the `PlayerController.cs` script for movement based on mouse input and interaction with objects in the game world.
- **Camera Control**: The `CameraController.cs` script allows for dynamic camera movement, including zoom and rotation around the player.
- **Inventory System**: Using `Inventory.cs`, `InventoryUI.cs`, and `InventorySlot.cs`, the game features a robust inventory system for managing and using items.
- **Equipment Management**: Equip and manage items with `Equipment.cs` and `EquipmentManager.cs`, allowing for changes in player stats and appearance.
- **Enemy AI**: Enemies, managed by `Enemy.cs` and `EnemyController.cs`, can detect and follow the player, providing engaging gameplay challenges.
- **Item Interaction**: Collect items in the world with `ItemPickup.cs`, which allows players to add items to their inventory by interacting with them.
- **Items**: Define game items using the `Item.cs` script, which can be extended for various types of items such as equipment and consumables.

## Setup

1. **Clone the Repository**: Start by cloning this repository to your local machine.
2. **Open in Unity**: Open the project in Unity by selecting the project folder in Unity Hub.
3. **Load the Main Scene**: Navigate to the Scenes folder and open the main game scene.
4. **Review the Scripts**: Familiarize yourself with the provided scripts and their functionalities as described above.
5. **Play the Game**: Press the Play button in Unity to start the game and test its features.

## Project Structure

- **Scripts**: Contains all game logic and functionality.
  - Movement, interaction, and camera control: `PlayerController.cs`, `CameraController.cs`.
  - Inventory system: `Inventory.cs`, `InventoryUI.cs`, `InventorySlot.cs`.
  - Equipment management: `Equipment.cs`, `EquipmentManager.cs`.
  - Enemy AI and behavior: `Enemy.cs`, `EnemyController.cs`.
  - Item interaction and definition: `Interactable.cs`, `Item.cs`, `ItemPickup.cs`.

## Contributing

Contributions to the project are welcome! Follow these steps to contribute:
1. Fork the repository.
2. Create a new branch for your feature.
3. Commit your changes.
4. Push to the branch.
5. Submit a pull request.

## Acknowledgments
All assets such as characters, models, icons, and animations were scavenged from the Unity Asset Store.
