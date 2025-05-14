# OP2TileGroupTools

![Screenshot](https://images.outpostuniverse.org/OP2TileGroupTools.png)

## What is it?
OP2TileGroupTools is a simple utility application for working with Outpost 2: Divided Destiny map files. It exports the the tile groups to JSON format from within a map file. It also creates a map file containing all exported tile groups.

## What it does:

### Open Map Files
- Opens Outpost 2 map files (.map)
- Shows basic map information like size and available tile groups

### Export Tile Groups
- Saves all tile groups from a map as individual JSON files
- Creates these files in a folder called "TileGroupExports"

### Create Tile Group Map
- Makes a new map containing all exported tile groups
- Places the tile groups in an organized layout
- Open's the map in OP2MapViewer to see the results

## How to use:
1. Click "Open Map" to load an Outpost 2 map file
2. Click "Export Tile Groups" to save all tile groups as JSON
3. Click "Create Map" to build a new map with all tile groups

## Tile Group JSON Format

Each tile group is stored as a separate JSON file with the following structure:

```json
{
  "header": {
    "width": 6,          // Width of the tile group in tiles
    "height": 3,         // Height of the tile group in tiles
    "tileset": "well00", // Tileset identifier
    "name": "snowroc7",  // Name of the tile group
    "bmp": "",           // Reserved for bitmap reference
    "notes": ""          // Optional notes
  },
  "tiles": [
    [ 1898, 1899, 1900, 1901, 1902, 1903 ],  // First row
    [ 1904, 1905, 1906, 1907, 1908, 1909 ],  // Second row
    [ 1910, 1911, 1912, 1913, 1914, 1915 ]   // Third row
  ]
}
```
