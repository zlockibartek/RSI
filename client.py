import requests

BASE_URL = "http://zpi03.solidcp.ii.pwr.edu.pl/RestService.svc"

while(True):
    print()
    print("________________________________________")
    print("get_authors | wyświetl wszystich autorów")
    print("get_author  | wyświetl autora o ID")
    print("get_items   | wyświetl wszystkie książki")
    print("get_item    | wyświetl książkę o ID")
    print("add_item    | dodaj książkę")
    print("edit_item   | edytuj książkę")
    print("delete_item | usuń książkę")
    print("exit        | wyjście")
    option = input("-> ")
    print("________________________________________")

    if option == "get_authors":
        response = requests.get(f"{BASE_URL}/json/authors")
        print(response.text)

    if option == "get_author":
        id = input("ID -> ")
        response = requests.get(f"{BASE_URL}/json/authors/{id}")
        print(response.text)

    if option == "get_items":
        response = requests.get(f"{BASE_URL}/json/items")
        print(response.text)
    
    if option == "get_item":
        id = input("ID -> ")
        response = requests.get(f"{BASE_URL}/json/items/{id}")
        print(response.text)
    
    if option == "add_item":
        data = {}
        data['ID'] = int(input("ID -> "))
        data['Name'] = input("Name -> ")
        data['Author'] = int(input("Author -> "))
        response = requests.post(f"{BASE_URL}/json/items", json=data)
        print(response.text)
    
    if option == "edit_item":
        data = {}
        data['ID'] = int(input("ID -> "))
        data['Name'] = input("Name -> ")
        data['Author'] = int(input("Author -> "))
        response = requests.put(f"{BASE_URL}/json/items/{data['ID']}", json=data)
        print(response.text)
    
    if option == "delete_item":
        data = {}
        data['ID'] = int(input("ID -> "))
        response = requests.delete(f"{BASE_URL}/json/items/{data['ID']}")
        print(response.text)

    if option == "exit":
        exit()