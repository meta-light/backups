from selenium.webdriver import Chrome, ChromeOptions
from selenium.webdriver.common.by import By
from selenium.common.exceptions import StaleElementReferenceException
import time
from flask import Flask, jsonify

def get_data(url) -> list:
    browser_options = ChromeOptions()
    browser_options.headless = True
    browser_options.add_argument("--disable-gpu")
    driver = Chrome(options=browser_options)
    driver.get(url)
    data = []
    time.sleep(5)
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    time.sleep(5)
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    time.sleep(5)
    try:
        node_name_elements = driver.find_elements(By.XPATH, "//h1[contains(@class, 'text-xl font-semibold text-black dark:text-white')]")
        status_elements = driver.find_elements(By.XPATH, "//span[contains(@class, 'text-moken-dark-gray') or contains(@class, 'text-moken-green')]")
        for node_name_element, status_element in zip(node_name_elements, status_elements):
            try: node_name = "-".join(node_name_element.text.lower().split())
            except StaleElementReferenceException:
                node_name_element = driver.find_element(By.XPATH, "//h1[contains(@class, 'text-xl font-semibold text-black dark:text-white')]")
                node_name = "-".join(node_name_element.text.lower().split())
            try: status = "Active" if "text-moken-green" in status_element.get_attribute("class") else "Inactive" if "text-moken-dark-gray" in status_element.get_attribute("class") else "Unknown"
            except StaleElementReferenceException:
                status_element = driver.find_element(By.XPATH, "//span[contains(@class, 'text-moken-dark-gray') or contains(@class, 'text-moken-green')]")
                status = "Unknown"
            data.append({"Mycelium Node Name": node_name, "Status": status})
    finally: driver.quit()
    return data

def main():
    wallets = [
        "https://explorer.moken.io/wallets/HtcyMqAuxtmZwA6FcXQpQSvLzPRLgoHotPMWp8hooA4Y", #IOT - 257
        "https://explorer.moken.io/wallets/DtRt4DVAgKzK1EZjmJsNk5ke5jygk84f4FMUDBZPA2i2", #LR WIFI - 6
        "https://explorer.moken.io/wallets/J1cXdw1P39ouCukH76ifhizhyS6AgBXw9RnCbmNebaN3", #WIFI - 29
        "https://explorer.moken.io/wallets/3GVSxYJMpS2VqMijXP9bD1eBGCH3pR9F8tbRgLbS2QdN" #CBRS - 44
    ] 
    all_data = []
    for link in wallets:
        data = get_data(link)
        all_data.extend(data)
    print(len(all_data)) #Target - 336

    app = Flask(__name__)
    @app.route('/api/data', methods=['GET'])
    def get_all_data(): return jsonify(all_data)
    if __name__ == '__main__': app.run(debug=True)
    
if __name__ == "__main__": main()

# headless runtime