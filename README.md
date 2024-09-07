# Sesuruk
Sesuruk is a Windows Form Application developed using C# on the .NET Framework 4.8. This application allows users to import sound effects and play them through their microphone, making it ideal for online gaming, voice chats, or other voice-based applications. Sesuruk is aims to offer an easy-to-use interface for adding fun sound effects to your audio stream.

## Features
- **Import Sound Effects**: Easily add custom sound effects from your local files.
- **Play Sounds via Microphone**: Sesuruk enables playing sound effects directly through the microphone, allowing others to hear the effects in real-time during voice chats.
- **User-Friendly Interface**: The application features a simple and intuitive interface for managing and playing sound effects.
- **Real-Time Playback**: Low-latency sound playback ensures smooth audio transmission without delays.
- **VBCABLE Support**: Sesuruk integrates with the third-party **VBCABLE_Setup_x64** driver to enable audio routing to the microphone.

## Prerequisites
To run Sesuruk, ensure your system meets the following requirements:
- Windows OS (7, 8, 10, or later)
- .NET Framework 4.8
- A microphone and speakers or headphones for sound input and output
- [VBCABLE_Setup_x64](https://vb-audio.com/Cable/) driver installed (for playing sounds via the microphone)

> **Note**: Sesuruk uses the third-party **VBCABLE_Setup_x64** driver for routing audio through the microphone. Please ensure that the driver is installed and configured correctly on your system.

## Installation
1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/sesuruk.git
   ```
2. **Build the project**: Open the solution file (.sln) in Visual Studio, then build the project to compile the application.
3. **Install VBCABLE Driver**: Download and install the VBCABLE_Setup_x64 driver from VBCABLE official website (if you use installer you don't need download it).
4. **Run the application**: After building, run the application from Visual Studio, or find the executable in the bin/Debug folder.

## How to Use
1. **Import Sounds**:
- Launch the Sesuruk application.
- Use the "Add Sound" button to add sound files (supports .wav, .mp3, .ogg, etc.).

2. **Configure VBCABLE**:
- Install and set up the VBCABLE driver on your system.
- Set VBCABLE as the default microphone input in your sound settings.
- If you use Sesuruk installer you don't need to download and install this driver.

3. **Play Sounds**:
- Select a sound from the list of imported sounds.
- Click "Play" to broadcast the sound via your microphone using the VBCABLE driver.
- Enable 'Play on speaker also' option for head sound from your headset or speaker.

## Contributing
Contributions are welcome! If you have suggestions for new features, bug fixes, or improvements, please follow these steps:

1. **Fork the repository**.
2. **Create a new branch**:
   ```bash
   git checkout -b feature/your-feature
   ```
3. **Commit your changes**:
   ```bash
   git commit -m "Add your feature"
   ```
5. **Push to the branch**:
   ```bash
   git push origin feature/your-feature
   ```
7. **Create a pull request.**

## Issues
If you encounter any bugs or have feature requests, please create an issue on the GitHub repository.

## Acknowledgements
- Inspired by Soundpad.
- Developed with love using C# and .NET Framework 4.8.
- VBCABLE driver used for audio routing to the microphone.
