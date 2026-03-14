#!/bin/bash

echo "Deploying application to main..."

# Example build
npm install
npm run build

# Example deploy
scp -r build/* user@main-server:/var/www/app

echo "Deployment to main complete!"