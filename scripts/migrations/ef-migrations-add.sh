read -p "Migration Name: " migration_name

if [ -z "$migration_name" ];
then
    echo "Empty Migration Name"
    exit 0
fi

cd ../../src/Migrations
dotnet ef migrations add $migration_name