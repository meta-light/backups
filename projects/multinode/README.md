# multinode
Research around the application of low-power cluster computing in blockchain node operation

Most blockchain nodes are deployed on personal computers. 90% of these nodes are lightweight and require less than 10% of the compute power present on a standard PC, but are deployed in cush a way that thier efficency and carbon footprint reduction are not realized. 

## Motivation 
* https://twitter.com/META_DREAMER/status/1553454222489702401?s=20&t=RXPTUOYUuT6KO-iLMgL44g
* https://twitter.com/AriSokolov/status/1537454383746600963?s=20&t=5YUGQ7aZhK1rasW5TU4DEQ
* https://twitter.com/level39/status/1548550264218583040?s=20&t=5YUGQ7aZhK1rasW5TU4DEQ

## Hardware Recipt
| Hardware | Cost | Link |
| ---------|------|----- |
| 4x Raspberry Pi 4B | $180 | [link](https://www.raspberrypi.com/products/raspberry-pi-4-model-b/) |
| PoE Switch | $40 | [link](https://www.amazon.com/TP-Link-Compliant-Shielded-Optimization-TL-SG1005P/dp/B07PPJTR15/ref=sr_1_9?crid=28RQ54F4P87PD&keywords=poe+switch&qid=1661007238&sprefix=poe+switch%2Caps%2C166&sr=8-9) |
| Cluster Case | $65 | [link](https://www.amazon.com/dp/B0B3WTQSGL?psc=1&ref=ppx_yo2ov_dt_b_product_details) |
| 4x PoE Splitters | $30 | [link](https://www.amazon.com/dp/B08HZFS3PM?psc=1&ref=ppx_yo2ov_dt_b_product_details) |
| 5x 6 Inch Cat6 Cables | $10 | [link](https://www.amazon.com/iMBAPrice-Mixed-Colors-Snagless-Ethernet/dp/B00FH7B76M/ref=sr_1_19?crid=1LVRCKAIUDJZ0&keywords=6+inch+cat6&qid=1673286552&s=industrial&sprefix=6+inch+cat6%2Cindustrial%2C107&sr=1-19) | 
| 2x Micro HDMI adapter | $10 | [link](https://www.amazon.com/GANA-Adapter-Female-Action-Supported/dp/B07K21HSQX/ref=sxin_14_pa_sp_search_thematic-asin_sspa?content-id=amzn1.sym.075b4844-907e-4733-ac4c-baaec37ffd39%3Aamzn1.sym.075b4844-907e-4733-ac4c-baaec37ffd39&crid=20HUJHZKHM69E&cv_ct_cx=micro+hdmi&keywords=micro+hdmi&pd_rd_i=B07K21HSQX&pd_rd_r=5ec13119-1361-4ba3-99bc-607726ab6542&pd_rd_w=X0LAq&pd_rd_wg=ziNXA&pf_rd_p=075b4844-907e-4733-ac4c-baaec37ffd39&pf_rd_r=ES6EMQK54824TFRVH382&qid=1673286630&sprefix=micro+hdmi%2Caps%2C115&sr=1-4-4a643ae4-6005-4b15-bc31-2c5125e2b25b-spons&psc=1) |

## Software 
* K3
* Ceph
* Ansible
* https://github.com/geerlingguy/deskpi-super6c-cluster
* https://www.youtube.com/playlist?list=PL2_OBreMn7FqZkvMYt6ATmgC0KAGGJNAN
* https://www.youtube.com/watch?v=X9fSMGkjtug&list=WL&index=1 Kubrenettes

## Protocols
* Mysterium $MYST - CPU: 1 core -RAM: 1GB -DISK: 500MB 
* Computecoin $CCN - Hardware: Intel Core i5-3470S, 16 GB DDR3 RAM, 512GB SSD Disk Collateral required: 5.1 USDT - based on power
* Presearch $PRE - CPU: 1 core -RAM: 1GB -DISK: 1GB - 4000 PRE stake 
* Storj $STORJ - CPU: 1 Core - 550 GB disk - 2TB Bandwidth/month
* Pocket Network $POKT - 4 core| 16 GB RAM | 200GB Disk
* PKT $PKT - Raspberry Pi compatible
* Flux $FLUX - 2 Cores 8 GB RAM 220 GB SSD/NVME
* Chia
* Subspace
* Duino Coin
* Ankr
* BlockPi
* POKT
* Umbrel
