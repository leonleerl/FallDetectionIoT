# Fall Detection System

A comprehensive fall detection system designed for elderly care, combining hardware sensors with software applications to provide real-time monitoring and emergency response capabilities.

## Main Features

- **Real-time Fall Detection**: Continuous monitoring using accelerometer data to detect sudden falls
- **GPS Location Tracking**: Accurate positioning information for emergency response
- **Desktop Monitoring Application**: User-friendly interface for caregivers and family members
- **Web API Integration**: RESTful API for data management and communication
- **Emergency Alerts**: Automatic notifications when a fall is detected
- **Data Logging**: Historical data storage and analysis capabilities

## Tech Stack

### Hardware

- **MPU6050**: 6-axis accelerometer and gyroscope sensor for motion detection
- **ESP32 TTGO T-Beam**: GPS module with built-in LoRa capabilities for location tracking

### Software

- **Arduino**: Firmware development for sensor data collection and processing
- **C# WPF**: Desktop application for monitoring and management interface
- **C# Web API**: Backend service for data handling and communication
- **.NET Framework**: Core development platform for software components

## Architecture Overview

The system consists of three main components:

1. **Hardware Layer**: Sensor modules for data collection
2. **Desktop Application**: Real-time monitoring and control interface
3. **Web API**: Data processing and communication backend
