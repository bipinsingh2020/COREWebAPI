#!/bin/bash

echo "Deploying application to staging..."

# Example build
npm install
npm run build

# Example deploy
scp -r build/* user@staging-server:/var/www/app

echo "Deployment to staging complete!"